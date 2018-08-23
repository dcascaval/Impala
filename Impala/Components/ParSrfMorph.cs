using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;
using SquishyXMorphs;
using Rhino.Geometry;

using static Impala.Generated;
using static Impala.Errors;
using static Impala.Utilities;

namespace Impala
{
    public class ParSrfMorph : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParSrfMorph class.
        /// </summary>
        public ParSrfMorph()
          : base("ParSurfaceMorph", "ParSrfMorph",
              "Morph geometry into surface UVW coordinates",
              "Impala", "Transform")
        {
            var error = new Error<(IGH_GeometricGoo, GH_Box, GH_Surface, GH_Interval, GH_Interval, GH_Interval)>(NullCheck, NullHandle, this);
            var smerror = new Error<(IGH_GeometricGoo, GH_Box, GH_Surface, GH_Interval, GH_Interval, GH_Interval)>(SmallCheck, SmallHandle, this);
            CheckError = new ErrorChecker<(IGH_GeometricGoo, GH_Box, GH_Surface, GH_Interval, GH_Interval, GH_Interval)>(error, smerror);
        }

        public ErrorChecker<(IGH_GeometricGoo, GH_Box, GH_Surface, GH_Interval, GH_Interval, GH_Interval)> CheckError;
        static Func<(IGH_GeometricGoo, GH_Box, GH_Surface, GH_Interval, GH_Interval, GH_Interval), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3 != null && a.Item4 != null && a.Item5 != null && a.Item6 != null);
        static Func<(IGH_GeometricGoo, GH_Box, GH_Surface, GH_Interval, GH_Interval, GH_Interval), bool> SmallCheck = a => a.Item2.Value.Volume > 1e-16;
        static Action<GH_Component> SmallHandle = c => c.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Cannot morph degenerate box.");
        static Action<GH_Component> ZeroHandle = c => c.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Surface space extents cannot be zero.");
        static Func<(IGH_GeometricGoo, GH_Box, GH_Surface, GH_Interval, GH_Interval, GH_Interval), bool> ZeroCheck = a => (!a.Item4.Value.IsSingleton && !a.Item5.Value.IsSingleton && !a.Item6.Value.IsSingleton);

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddGeometryParameter("Geometry", "G", "Base Geometry", GH_ParamAccess.tree);
            pManager.AddBoxParameter("Reference", "R", "Reference Box", GH_ParamAccess.tree);
            pManager.AddSurfaceParameter("Surface", "S", "Surface to map to", GH_ParamAccess.tree);
            pManager.AddIntervalParameter("U Domain", "U", "Surface space U extents", GH_ParamAccess.tree, new Interval(0.0, 1.0));
            pManager.AddIntervalParameter("V Domain", "V", "Surface space V extents", GH_ParamAccess.tree, new Interval(0.0, 1.0));
            pManager.AddIntervalParameter("W Domain", "W", "Surface space W extents", GH_ParamAccess.tree, new Interval(0.0, 1.0));
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddGeometryParameter("Geometry", "G", "Transformed geometry", GH_ParamAccess.tree);
        }

        public static IGH_GeometricGoo SrfMorpher(IGH_GeometricGoo geo, GH_Box gref, GH_Surface gtarg, GH_Interval gu, GH_Interval gv, GH_Interval gw)
        {
            var targ = gtarg.Value.Faces[0].DuplicateSurface();
            var refbox = gref.DuplicateBox().Value;
            var u = gu.DuplicateInterval().Value;
            var v = gv.DuplicateInterval().Value;
            var w = gw.DuplicateInterval().Value;

            var morph = new Component_MorphToSurfaceSpace.SurfaceUVWSpaceMorph(targ, refbox, u, v, w);
            morph.PreserveStructure = false;
            morph.QuickPreview = false;
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
            if (!DA.GetDataTree(2, out GH_Structure<GH_Surface> targTree)) return;
            if (!DA.GetDataTree(3, out GH_Structure<GH_Interval> utree)) return;
            if (!DA.GetDataTree(4, out GH_Structure<GH_Interval> vtree)) return;
            if (!DA.GetDataTree(5, out GH_Structure<GH_Interval> wtree)) return;
            
            var gx = Zip6x1(geoTree, refTree, targTree,utree,vtree,wtree,SrfMorpher, CheckError);

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
            get { return new Guid("8670800B-274B-49FB-9632-0ACE90D94492"); }
        }
    }
}