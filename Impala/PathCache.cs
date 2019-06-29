using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

using Rhino.Geometry;

namespace Impala
{
  public class PathCache
  {
    // Todo: We can generalize this into a tree, useful for grafted ones esp.
    class PathRange
    {
      public GH_Path Start; // Starting path
      public int Incr; // How many paths it contains (minimum = 1)
    }

    private List<PathRange> Cache;
    private List<int> Indices;
    public readonly int PathLen = 0;
    private readonly int MaxIdx = 0; 

    //@ Require: all paths must be of the same length before being fed here. 
    public PathCache(GH_Path[] paths)
    {
      Cache = new List<PathRange>();
      Indices = new List<int>() { 0 };
      if (paths.Length == 0) return;

      PathLen = paths[0].Length - 1;
      var range = new PathRange { Start = paths[0], Incr = 1 };
      for (int i = 1; i < paths.Count(); i++)
      {
        // Check that the two paths are corresponding.
        bool same = SameTo(paths[i - 1], paths[i], PathLen);

        // If they are, and also adjacent, we increment. 
        if (same && paths[i-1][PathLen] == paths[i][PathLen] - 1) {
          range.Incr++; 
        }
        // If they're not, we start afresh. 
        else { 
          Cache.Add(range);
          range = new PathRange { Start = paths[i], Incr = 1 };
        }
      }
      Cache.Add(range);


      int total = 0;
      foreach (var r in Cache)
      {
        total += r.Incr;
        Indices.Add(total);
      }
      MaxIdx = total;
    }

    // Helper function to determine if two paths are equal to each other up to a point.
    private bool SameTo(GH_Path a, GH_Path b, int idx)
    {
      bool same = true;
      for (int j = 0; j < idx; j++)
      {
        same &= a[j] == b[j];
        if (!same) break;
      }
      return same;
    }

    // Minor adaptaion of binary search.
    private int LowerClosestElement(List<int> indices, int searchTerm, int minIdx, int maxIdx)
    {
      if (maxIdx - minIdx < 2) return minIdx;
      var mid = minIdx + (maxIdx - minIdx) / 2;
      if (searchTerm < indices[mid]) return LowerClosestElement(indices, searchTerm, minIdx, mid);
      if (searchTerm > indices[mid]) return LowerClosestElement(indices, searchTerm, mid, maxIdx);
      return mid;
    }

    // Get the index of a path in the cache (this will be the index
    // of the branch in the flat DS)
    public int? Index(GH_Path path)
    {
      for (int i = 0; i < Cache.Count(); i++)
      {
        var r = Cache[i];
        bool same = SameTo(r.Start, path, PathLen);
        if (!same) continue;

        int diff = path[PathLen] - r.Start[PathLen] - 1;
        if (diff <= r.Incr) return Indices[i] + diff;
      }
      return null; // Not found.
    }


    // Get the path of a specific index. Null if out of bounds.
    public GH_Path Path(int index)
    {
      if (index < 0 || index > MaxIdx) return null;
      var resultIdx = Indices[LowerClosestElement(Indices,index,0,Indices.Count() - 1)];
      var startPath = Cache[resultIdx];
      return startPath.Start.Increment(PathLen, index - resultIdx);
    }

    public GH_Path[] GetAllPaths()
    {
      var result = new GH_Path[MaxIdx];
      int i = 0; 
      foreach (var r in Cache)
      {
        for (int j = 0; j < r.Incr; j++)
        {
          result[i] = r.Start.Increment(PathLen, j);
          i++;
        }
      }
      return result;
    }
  }
}
