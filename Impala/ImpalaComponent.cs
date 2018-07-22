using System;
using System.Linq;
using System.Collections.Generic;

using Rhino.Geometry;
using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

using static Impala.Generic;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace Impala
{
    public class ManualPaths : GH_Component
    {
        /// <summary>
        /// 
        /// </summary>
        public ManualPaths()
          : base("Manual Div", "TestDivManual",
              "Impala Generic testing",
              "Impala", "Test")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("A", "A", "Number", GH_ParamAccess.tree);
            pManager.AddNumberParameter("B", "B", "Number", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("R", "R", "Result of division operation", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Testing component for structures and operations in Impala.Generic
        /// </summary>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetDataTree(0, out GH_Structure<GH_Number> a1)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Number> b1)) return;

            var result = ZipMaxManual(a1, b1, (a, b) => new GH_Number(a.Value / b.Value));
            DA.SetDataTree(0,result);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("206902ad-085d-49e1-953e-4b5246878c81"); }
        }
    }

    public class AutoPaths : GH_Component
    {
        /// <summary>
        /// 
        /// </summary>
        public AutoPaths()
          : base("Parallel Div", "TestDivPar1",
              "Impala Generic testing",
              "Impala", "Test")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("A", "A", "Number", GH_ParamAccess.tree);
            pManager.AddNumberParameter("B", "B", "Number", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("R", "R", "Result of division operation", GH_ParamAccess.tree);
        }

        protected override void BeforeSolveInstance()
        {
            base.BeforeSolveInstance();
        }

        /// <summary>
        /// Testing component for structures and operations in Impala.Generic
        /// </summary>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetDataTree(0, out GH_Structure<GH_Number> a1)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Number> b1)) return;

            var result = ZipMaxParallel1D(a1,b1, (a, b) => new GH_Number(a.Value / b.Value));
            DA.SetDataTree(0, result);
        }

        protected override void AfterSolveInstance()
        {
            base.AfterSolveInstance();
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("512DE9EA-337B-4ECD-B107-B1814DFD7F59"); }
        }
    }

    public class ParDiv2D : GH_Component
    {
        /// <summary>
        /// 
        /// </summary>
        public ParDiv2D()
          : base("Parallel Div", "TestDivPar2",
              "Impala Generic testing",
              "Impala", "Test")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("A", "A", "Number", GH_ParamAccess.tree);
            pManager.AddNumberParameter("B", "B", "Number", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("R", "R", "Result of division operation", GH_ParamAccess.tree);
        }

        protected override void BeforeSolveInstance()
        {
            base.BeforeSolveInstance();
        }

        /// <summary>
        /// Testing component for structures and operations in Impala.Generic
        /// </summary>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetDataTree(0, out GH_Structure<GH_Number> a1)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Number> b1)) return;

            var result = ZipMaxParallel2D(a1, b1, (a, b) => new GH_Number(a.Value / b.Value));
            DA.SetDataTree(0, result);
        }

        protected override void AfterSolveInstance()
        {
            base.AfterSolveInstance();
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("9FF71D26-F8D2-4F72-8DC0-BF53D5B09E89"); }
        }
    }
}
