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
    int numBranches;
    int[] sizePerBranch;

    GH_Path[] paths;
    int[][] data;
    int totalSize;

    // We'll try to keep path info consistent. We fully one-shot the allocation here
    // in order to save us a whole load of time when it comes to the .Add() methods.
    public ImpalaStructure(int numBranches, int[] sizePerBranch, GH_Path[] paths)
    {

      // We save everything here.
      this.numBranches = numBranches;
      this.sizePerBranch = sizePerBranch;
      this.paths = paths;
      this.data = new int[numBranches][];

      int total = 0;
      for (int i = 0; i < numBranches; i++)
      {
        int size = sizePerBranch[i];
        total += size;
        data[i] = new int[size];
      }

      totalSize = total;
    }

    public static explicit operator ImpalaStructure<T>(GH_Structure<T> other) // Woo, conversions.
    {
      return null;
    }

    // Standard data structure operations
    public bool IsEmpty => totalSize == 0;
    public int PathCount => numBranches;
    public int DataCount => totalSize;
    public IList<GH_Path> Paths => paths;

    public string TopologyDescription
    {
      get
      {
        if (totalSize == 0) return "empty data";
        return $"Data with {numBranches} branches";
        //@TODO: add the rest of the string in a builder. (sizeperbranch info).
      }
    }

    public IGH_StructureEnumerator AllData(bool skipNulls)
    {
      throw new NotImplementedException();
    }

    // What this
    public string DataDescription(bool includeIndices, bool includePaths)
    {
      throw new NotImplementedException();
    }

    // Also, what this
    public void ExpandPath(GH_Path path, int element, GH_ExpandMode mode)
    {
      throw new NotImplementedException();
    }


    // Warning: not efficient.
    public IList get_Branch(GH_Path path)
    {
      // We don't key by path.
      // We Introduce: A Level Of Indirection.
      // branch -> table -> index -> data[index]
      return null;
    }

    public IList get_Branch(int index)
    {
      return data[index];
    }

    public GH_Path get_Path(int index)
    {
      return paths[index];
    }

    public int LongestPathIndex()
    {
      GH_Path maxPath = null;
      int max = 0;
      for (int i = 0; i < numBranches; i++)
      {
        if (maxPath == null || maxPath.Length < paths[i].Length)
        {
          maxPath = paths[i];
          max = i;
        }
      }

      return max; // The actual index, not the path itself.
    }

    public bool PathExists(GH_Path path)
    {
      foreach (var gpath in paths)
      {
        if (gpath.IsCoincident(path)) return true;
      }
      return false;
    }

    public void PathIndex(GH_Path path, ref int idx0, ref int idx1)
    {
      throw new NotImplementedException();
    }

    public int ShortestPathIndex()
    {
      GH_Path minPath = null;
      int min = 0;
      for (int i = 0; i < numBranches; i++)
      {
        if (minPath == null || minPath.Length > paths[i].Length)
        {
          minPath = paths[i];
          min = i;
        }
      }

      return min; // The actual index, not the path itself.
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
