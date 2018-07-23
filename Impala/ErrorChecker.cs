using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;

namespace Impala
{
    static class Errors
    {
        public static Action<GH_Component> NullHandle = comp => comp.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Null value!");
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