using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;

namespace Impala
{
    static class Errors
    {
        public static bool EmptyCheck<T>(List<T> input)
        {
            return input.Count != 0;
        }
        public static Action<GH_Component> NullHandle = comp => comp.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Null value!");
        public static Action<GH_Component> EmptyHandle = comp => comp.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Empty Branch!");

        public static bool CheckListNull<T>(List<T> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == null) return false;
            }
            return true;
        }
    }

    public class ErrorChecker<T>
    {
        List<Error<T>> errs;

        public ErrorChecker(params Error<T>[] errlist)
        {
            errs = new List<Error<T>>(errlist);
        }

        public void AddError(Error<T> error)
        {
            errs.Add(error);
        }


        public bool Validate(T input)
        {
            bool flag = true;
            foreach (var err in errs)
            {
                flag &= err.Validate(input);
                if (!flag) return false;
            }
            return flag;
        }
    }

    public class Error<T>
    {
        private readonly Func<T, bool> check;
        private readonly Action<GH_Component> handle;
        private readonly GH_Component comp;

        public Error(Func<T, bool> check, Action<GH_Component> handle, GH_Component comp)
        {
            this.check = check;
            this.handle = handle;
            this.comp = comp;
        }

        public bool Validate(T input)
        {
            if (!check(input))
            {
                handle(comp);
                return false;
            }
            return true;
        }

    }
}