using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace Impala
{
    public class ImpalaInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "Impala";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "Parallel components for scalable and physical design computation";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("f0950c51-e05e-4f9e-b61e-16b335abfcdd");
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
