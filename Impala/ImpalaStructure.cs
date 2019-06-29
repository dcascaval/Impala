using GH_IO;
using GH_IO.Serialization;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Attributes;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Types;
using Rhino;
using Rhino.DocObjects;
using Rhino.Geometry;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Impala
{
  // ImpalaStructure for basic conversion operations. We should allow this to be made in/out of GH_Structure <T>
  public class ImpalaStructure<T> : IGH_Structure, IEnumerable<T>, GH_ISerializable where T : IGH_Goo
  {
    int[] sizePerBranch;

    // We can definitely find a method of saving on these. The vast majority of the paths are redundant
    // if we can describe the pattern that they have and are able to extract them from this. 
    PathCache paths;
    T[][] data;

    // We'll try to keep path info consistent. We fully one-shot the allocation here
    // in order to save us a whole load of time when it comes to the .Add() methods.
    public ImpalaStructure(int numBranches, int[] sizePerBranch, GH_Path[] paths)
    {

      // We save everything here.
      // We can also try implementing this structure with a flat array, 
      // especially as we tend to iterate through it linearly. Needs more profiling.
      this.PathCount = numBranches;
      this.sizePerBranch = sizePerBranch;
      this.paths = new PathCache(paths);
      this.data = new T[numBranches][];

      int total = 0;
      for (int i = 0; i < numBranches; i++)
      {
        int size = sizePerBranch[i];
        total += size;
        data[i] = new T[size];
      }

      DataCount = total;
    }

    // This will enable us to just test things
    public static explicit operator ImpalaStructure<T>(GH_Structure<T> other) // Woo, conversions.
    {
      var branches = other.Branches.Count;
      var sizePerBranch = other.Branches.Select(b => b.Count).ToArray();
      var paths = other.Paths.ToArray(); // Todo: path reduction algorithm 
      return new ImpalaStructure<T>(branches, sizePerBranch, paths);
    }

    // This is inevitable when the ImpalaStructure gets passed to a normal GH_Param<T> 
    // and is manually cast into a GH_Structure in order to merge it. So we make a shallow copy.
    public static explicit operator GH_Structure<T>(ImpalaStructure<T> self)
    {
      var result = new GH_Structure<T>();
      var allPaths = self.paths.GetAllPaths();
      for (int i = 0; i < self.PathCount; i++)
      {
        result.AppendRange(self.data[i], allPaths[i]);
      }
      return result; 
    }


    // Standard data structure operations
    public bool IsEmpty => DataCount == 0;
    public int PathCount { get; }
    public int DataCount { get; }

    //@ INEFFICIENCY WARNING @//
    // Do not call this. Just don't do it. It's there to spoof the stupid interface
    // and be passed around. Cast it to GH_Structure when you need to, but don't use this.
    public IList<GH_Path> Paths => null;

    public string TopologyDescription
    {
      get
      {
        if (DataCount == 0) return "empty data";
        return $"Data with {PathCount} branches";
        //@TODO: add the rest of the string in a builder. (sizeperbranch info).
      }
    }

    struct AllDataEnumerator : IEnumerator<IGH_Goo>, IGH_StructureEnumerator
    {
      ImpalaStructure<T> structure;
      int branch;
      int item;
      readonly bool nulls;

      public IGH_Goo Current => structure.data[branch][item];
      object IEnumerator.Current => structure.data[branch][item];

      public AllDataEnumerator(ImpalaStructure<T> structure, bool skipNulls)
      {
        this.structure = structure;
        nulls = skipNulls;
        branch = 0;
        item = -1; 
      }

      public void Dispose()
      {
        structure = null;
      }

      public bool MoveNext()
      {
        // Oop, already out of range.
        if (branch >= structure.data.Length)
          return false;

        // The next one works!
        item++;
        if (item < structure.data[branch].Length &&
           (structure.data[branch][item] != null || !nulls))
          return true;
        
        // Keep going until we find a non-null.
        while (item < structure.data[branch].Length && 
               structure.data[branch][item] == null && nulls)
          item++; 

        // Did we run out of space?
        if (item < structure.data[branch].Length)
          return true;

        // Skip all the empty branches
        item = -1;
        branch++;
        while (branch < structure.data.Length)
        {
          // Check the whole branch for any non-nulls if we're skipping.
          for (int i = 0; i < structure.data[branch].Length; i++)
          {
            if (!nulls || structure.data[branch][i] != null)
            {
              item = i;
              break;
            }
          }

          if (item >= 0) break;
          branch++;
        }
         
        // Done, start a new one.
        return branch < structure.data.Length;
      }

      public void Reset()
      {
        branch = 0;
        item = -1;
      }

      // Satisfy the silly interface
      public IEnumerator<IGH_Goo> GetEnumerator() { return this; }
      IEnumerator IEnumerable.GetEnumerator() { return this; }
    }

    // Enumerify the datums.
    public IGH_StructureEnumerator AllData(bool skipNulls)
    {
      return new AllDataEnumerator(this, skipNulls);
    }

    public string DataDescription(bool includeIndices, bool includePaths)
    {
      return ""; // Don't describe just yet.
    }

    // Also, what this. Do we want to support it?
    public void ExpandPath(GH_Path path, int element, GH_ExpandMode mode)
    {
    }


    // Warning: not quite as efficient as one might like. 
    public IList get_Branch(GH_Path path)
    {
      var idx = paths.Index(path);
      return idx.HasValue ? data[idx.Value] : null;
    }

    public IList get_Branch(int index)
    {
      return data[index];
    }

    public GH_Path get_Path(int index)
    {
      return paths.Path(index);
    }

    // All paths are equal, just return 0.
    public int LongestPathIndex()
    {
      if (PathCount == 0) return -1;
      return 0;
    }

    // Silly algorithm.
    public bool PathExists(GH_Path path)
    {
      return paths.Index(path) != null;
    }

    // Find larger & smaller paths to this one. 
    public void PathIndex(GH_Path path, ref int idx0, ref int idx1)
    {
      throw new NotImplementedException();
    }

    // All paths are equal, just return 0. 
    public int ShortestPathIndex()
    {
      if (PathCount == 0) return -1;
      return 0; 
    }

    // We have to implement these, since we're passing our thing to the output parameter.
    // And people want to do operations with that! Hahahahahah wellp. 
    // This is, I suppose, why we write our own ParamServers. But that's in the weeds.
    public void Flatten(GH_Path path = null) { }
    public void Simplify(GH_SimplificationMode mode) { }
    public void Graft(bool clearSingleNulls) { }
    public void Graft(GH_Path path, bool clearSingleNulls) { }
    public void Graft(GH_GraftMode mode) { }
    public void Graft(GH_GraftMode mode, GH_Path path) { }

    // METHODS THAT WE DON'T WANT TO IMPLEMENT BECAUSE IT DOESN'T MAKE SENSE

    // You don't wanna clear this.
    public void Clear() { }

    // You don't wanna clear this.
    public void ClearData() { }

    // Capacity has been ensured. Pray we do not ensure it further.
    public void EnsureCapacity(int capacity) => throw new NotImplementedException();

    // If you didn't want it, don't allocate it.
    public void TrimExcess() { }

    // If you didn't want it, don't put it there.
    public void RemovePath(GH_Path path) { }

    // Really.
    public void ReplacePath(GH_Path find, GH_Path replace) { }

    // Yo, what up with this? Serializers? 
    public IList<IList> StructureProxy => throw new NotImplementedException();

    // GH_ISerializable Implementation
    public bool Read(GH_IReader reader)
    {
      throw new NotImplementedException();
    }

    public bool Write(GH_IWriter writer)
    {
      throw new NotImplementedException();
    }

    // IEnumerable implementation 
    IEnumerator IEnumerable.GetEnumerator()
    {
      throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
      throw new NotImplementedException();
    }

  }
}
