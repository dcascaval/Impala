using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImpalaMethodGenerator
{

    public static class Extensions
    {
        public static T[] Array<T>(params T[] inputs)
        {
            return inputs;
        }

        public static int Max(params int[] inputs)
        {
            return inputs.Max();
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, params T[] elems)
        {
            return source.Concat(elems);
        }

        public static IEnumerable<int> IRange(int start, int end)
        {
            return Enumerable.Range(start, end - start);
        }

        public static IEnumerable<Q> SelEach<T, Q>(this IEnumerable<T> collection, Func<T, int, Q> action)
        {
            int i = 0;
            var result = new List<Q>();
            foreach (var item in collection)
            {
                result.Add(action(item, i));
                i++;
            }
            return result;
        }

        public static IEnumerable<string> MkStrings<T>(this IEnumerable<T> source)
        {
            return source.Select(x => x.ToString());
        }

        public static IEnumerable<T> SelRange<T>(this IEnumerable<T> range, int start, int end)
        {
            int currIndex = 0;
            var source = range.GetEnumerator();
            source.MoveNext();

            while (currIndex < end)
            {
                if (currIndex >= start)
                {
                    yield return source.Current;
                }
                source.MoveNext();
                currIndex++;
            }

            source.Dispose();
        }

        public static void DoEach<T>(this IEnumerable<T> collection, Action<T, int> action)
        {
            int i = 0;
            foreach (var item in collection)
            {
                action(item, i); i++;
            }
        }

        public static void DoEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}
