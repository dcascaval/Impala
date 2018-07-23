using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace Impala.MathComponents
{
    public class ImpalaInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "ImpalaQuickMath";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null; //Impala.Properties.Resources.impala_main;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "Fork of Impala : Parallel components for fast, generic math in Grasshopper";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("223830D7-8769-44A5-B0A9-14096E29FB8A");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "Dan Cascaval";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "cascaval@cmu.edu";
            }
        }
    }
}
