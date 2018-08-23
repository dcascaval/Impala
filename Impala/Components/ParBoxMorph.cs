using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;
using SquishyXMorphs;
using Rhino.Geometry;
using Rhino.Geometry.Intersect;

using static Impala.Generated;
using static Impala.Errors;
using static Impala.Utilities;

namespace Impala
{
    public class ParBoxMorph : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParBoxMorph class.
        /// </summary>
        public ParBoxMorph()
          : base("ParBoxMorph", "ParBoxMorph",
              "Perform a reference target box transform",
              "Impala", "Transform")
        {
            var error = new Error<(IGH_GeometricGoo, GH_Box, GH_TwistedBox)>(NullCheck, NullHandle, this);
            var smerror = new Error<(IGH_GeometricGoo, GH_Box, GH_TwistedBox)>(SmallCheck, SmallHandle, this);
            CheckError = new ErrorChecker<(IGH_GeometricGoo, GH_Box, GH_TwistedBox)>(error,smerror);
        }

        public ErrorChecker<(IGH_GeometricGoo, GH_Box, GH_TwistedBox)> CheckError;
        static Func<(IGH_GeometricGoo, GH_Box, GH_TwistedBox), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3 != null);
        static Func<(IGH_GeometricGoo, GH_Box, GH_TwistedBox), bool> SmallCheck = a => a.Item2.Value.Volume > 1e-16;
        static Action<GH_Component> SmallHandle = c => c.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Cannot morph degenerate box.");

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddGeometryParameter("Geometry", "G", "Base Geometry", GH_ParamAccess.tree);
            pManager.AddBoxParameter("Reference", "R", "Reference Box", GH_ParamAccess.tree);
            pManager.AddParameter(new Parameter_TwistedBox(), "Target", "T", "Target Box", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddGeometryParameter("Geometry", "G", "Transformed geometry", GH_ParamAccess.tree);
        }

        public static IGH_GeometricGoo BoxMorpher(IGH_GeometricGoo geo, GH_Box gref, GH_TwistedBox gtarg)
        {
            var box = ((GH_Box)gref.DuplicateGeometry()).Value;
            var targ = (GH_TwistedBox)gtarg.DuplicateGeometry();

            var morph = new Component_BoxMorph.GH_BoxMorph(box, targ);
            morph.PreserveStructure = false;
            morph.QuickPreview = false;
            morph.Tolerance = DocumentTolerance();
         
            var geox = geo.DuplicateGeometry();
            return geox.Morph(morph);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            if (!DA.GetDataTree(0, out GH_Structure<IGH_GeometricGoo> geoTree)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Box> refTree)) return;
            if (!DA.GetDataTree(2, out GH_Structure<GH_TwistedBox> targTree)) return;

            var gx = Zip3x1(geoTree, refTree, targTree, BoxMorpher, CheckError);

            DA.SetDataTree(0, gx);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("83028A17-8AE0-4E11-A409-2204E73B493E"); }
        }
    }
}