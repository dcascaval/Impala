using System;
using System.Collections.Generic;
using Grasshopper.Kernel;

namespace Impala.MathComponents
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
            foreach (var err in errs)
            {
                if (!err.Validate(input)) return false;
            }
            return true;
        }
    }

    public class Error<T>
    {
        Func<T, bool> check;
        Action<GH_Component> handle;
        GH_Component comp;

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