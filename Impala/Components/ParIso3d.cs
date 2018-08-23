using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;
using Rhino.Geometry.Intersect;

using static Impala.Utilities;
using static Impala.Generic;

namespace Impala.Components
{
    class ParIso3d : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParIso3D class.
        /// </summary>
        public ParIso3d()
          : base("ParIsoVist3D", "ParIso3D",
              "Shoot a ring of rays at a set of obstacles.",
              "Impala", "Intersection")
        {
            //var error = new Error<(GH_Mesh, GH_Point, GH_Vector)>(NullCheck, NullHandle, this);
            //CheckError = new ErrorChecker<(GH_Mesh, GH_Point, GH_Vector)>(error);
        }

        //public ErrorChecker<(GH_Mesh, GH_Point, GH_Vector)> CheckError;
        //static Func<(GH_Mesh, GH_Point, GH_Vector), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3 != null);


        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "P", "Source point for isovist sample", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Density", "D", "Sample density", GH_ParamAccess.item, 10);
            pManager.AddNumberParameter("Radius", "R", "Radius of isovist sampling", GH_ParamAccess.item, 100);
            pManager.AddMeshParameter("Obstacles", "O", "Obstacles in sampling", GH_ParamAccess.list);
            //2d interval density parameter? cull-style
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "X", "Isovist intersections", GH_ParamAccess.tree);
            pManager.AddIntegerParameter("Index", "I", "Index of obstacle hit", GH_ParamAccess.tree);
            pManager.AddBooleanParameter("Hit", "H", "Boolean indicating hit or miss", GH_ParamAccess.tree);
        }

        static IEnumerable<Point3d> ToPoints(Polyline p)
        {
            return p;
        }

        //Todo: add mesh sampling
        public static (GH_Point[], GH_Integer[], GH_Boolean[]) SolveIso3D(GH_Point gpt, GH_Integer gnum, GH_Number grad, List<GH_Mesh> gobs)
        {
            var meshes = gobs.Select(ob => ob.Value).ToArray();
            var sampleCenter = gpt.Value;
            var radius = grad.Value;
            var density = gnum.Value;
            var plane = Plane.WorldXY;
            plane.Translate(new Vector3d(sampleCenter));
            var baseSamples = MeshSphereSamples(plane, radius, density);
            var sortVecs = baseSamples.Vertices.Select(p => new Point3d(p.X, p.Y, p.Z)).Select(p => new Ray3d(sampleCenter, p - sampleCenter)).ToArray();

            var ptResults = new GH_Point[sortVecs.Length];
            var iResults = new GH_Integer[sortVecs.Length];
            var ixResults = new GH_Boolean[sortVecs.Length];

            Parallel.For(0, sortVecs.Length, j =>
            {
                var jRay = sortVecs[j];

                double bestIx = -1.0;
                int bestIdx = -1;
                for (int k = 0; k < meshes.Length; k++)
                {
                    var ix = Intersection.MeshRay(meshes[k], jRay);
                    if (ix < 0.0) continue;
                    else if (bestIx < 0.0 || ix < bestIx)
                    {
                        bestIx = ix;
                        bestIdx = k;
                    }
                }
                if (bestIx < 0.0) //failure, use radius
                {
                    ptResults[j] = new GH_Point(jRay.Position + jRay.Direction * radius);
                    iResults[j] = new GH_Integer(-1);
                    ixResults[j] = new GH_Boolean(false);
                }
                else
                {
                    //Cap radius
                    var pt2 = jRay.PointAt(bestIx);
                    if (pt2.DistanceTo(sampleCenter) > radius) pt2 = jRay.Position + jRay.Direction * radius;
                    ptResults[j] = new GH_Point(pt2);
                    iResults[j] = new GH_Integer(bestIdx);
                    ixResults[j] = new GH_Boolean(true);
                }
            });

            return (ptResults, iResults, ixResults);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var samplePt = new GH_Point();
            var numSamples = new GH_Integer();
            var radius = new GH_Number();
            var obstacles = new List<GH_Mesh>();

            if (!DA.GetData(0, ref samplePt)) return;
            if (!DA.GetData(1, ref numSamples)) return;
            if (!DA.GetData(2, ref radius)) return;
            if (!DA.GetDataList(3, obstacles)) return;

            //This requires a Zip5Red1xGraft3();

            if (obstacles.Count == 0)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "No obstacles to sample!");
                return;
            }

            if (numSamples == null || numSamples.Value <= 1)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Need at least density of 1.");
                return;
            }

            if (radius == null || radius.Value <= DocumentTolerance())
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Radius too small!");
                return;
            }

            var (pt, idx, ix) = SolveIso3D(samplePt, numSamples, radius, obstacles);
            DA.SetDataList(0, pt);
            DA.SetDataList(1, idx);
            DA.SetDataList(2, ix);
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
            get { return new Guid("C907CEA0-B9A3-45F5-944C-F7A85D2342F7"); }
        }

        //Radius must be positive
        //density must be at least 1
        private static Mesh MeshSphereSamples(Plane @base, double radius, int density)
        {
            var sphere = new Sphere(Plane.WorldXY, radius);
            var mesh = Mesh.CreateFromPlane(@base, new Interval(-radius, radius), new Interval(-radius, radius), density, density);
            mesh.Normals.Clear();

            for (int i = 0; i < mesh.Vertices.Count - 1; i++)
            {
                var cpt = sphere.ClosestPoint(mesh.Vertices[i]);
                var vec = new Vector3d(cpt);
                vec.Unitize();
                mesh.Vertices.SetVertex(i, cpt);
                mesh.Normals.SetNormal(i, vec);
            }

            var result = new Mesh();
            var origin = Point3d.Origin;
            var pi = Math.PI;
            var halfPI = pi / 2.0;

            result.Append(mesh);
            mesh.Rotate(halfPI, Vector3d.YAxis, origin);
            result.Append(mesh);
            mesh.Rotate(halfPI, Vector3d.YAxis, origin);
            result.Append(mesh);
            mesh.Rotate(halfPI, Vector3d.YAxis, origin);
            result.Append(mesh);
            mesh.Rotate(halfPI, Vector3d.ZAxis, origin);
            result.Append(mesh);
            mesh.Rotate(pi, Vector3d.ZAxis, origin);
            result.Append(mesh);
            Transform final = Transform.PlaneToPlane(Plane.WorldXY, @base);
            result.Transform(final);

            return result;
        }




        /* MESHSPHERE EX implementation
         * 		
        Plane unset = Plane.get_Unset();
		double num = double.NaN;
		int num2 = 0;
		if (DA.GetData<Plane>(0, ref unset) && DA.GetData<double>(1, ref num) && DA.GetData<int>(2, ref num2) && unset.get_IsValid() && RhinoMath.IsValidDouble(num))
		{
			num = Math.Abs(num);
			num = Math.Max(num, 1.4012984643248171E-42);
			if (num2 < 1)
			{
				this.AddRuntimeMessage(10, "At least one face is required.");
				num2 = 1;
			}
			Sphere val = default(Sphere);
			val..ctor(Plane.get_WorldXY(), num);
			Plane worldXY = Plane.get_WorldXY();
			worldXY.set_OriginZ(num);
			Plane val2 = worldXY;
			Interval val3 = default(Interval);
			val3..ctor(0.0 - num, num);
			Interval val4 = val3;
			Interval val5 = default(Interval);
			val5..ctor(0.0 - num, num);
			Mesh val6 = Mesh.CreateFromPlane(val2, val4, val5, num2, num2);
			val6.get_Normals().Clear();
			Mesh val9;
			checked
			{
				int num3 = val6.get_Vertices().get_Count() - 1;
				for (int i = 0; i <= num3; i++)
				{
					Point3d val7 = Point3d.op_Implicit(val6.get_Vertices().get_Item(i));
					val7 = val.ClosestPoint(val7);
					Vector3d val8 = default(Vector3d);
					val8..ctor(val7.get_X(), val7.get_Y(), val7.get_Z());
					val8.Unitize();
					val6.get_Vertices().SetVertex(i, val7);
					val6.get_Normals().SetNormal(i, val8);
				}
				val9 = new Mesh();
				val9.Append(val6);
				val6.Rotate(1.5707963267948966, Vector3d.get_YAxis(), Point3d.get_Origin());
				val9.Append(val6);
				val6.Rotate(1.5707963267948966, Vector3d.get_YAxis(), Point3d.get_Origin());
				val9.Append(val6);
				val6.Rotate(1.5707963267948966, Vector3d.get_YAxis(), Point3d.get_Origin());
				val9.Append(val6);
				val6.Rotate(1.5707963267948966, Vector3d.get_ZAxis(), Point3d.get_Origin());
				val9.Append(val6);
				val6.Rotate(3.1415926535897931, Vector3d.get_ZAxis(), Point3d.get_Origin());
				val9.Append(val6);
				Transform val10 = Transform.PlaneToPlane(Plane.get_WorldXY(), unset);
				val9.Transform(val10);
			}
			DA.SetData(0, (object)val9);
            */
    }
}
