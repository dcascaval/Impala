using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;

namespace Impala
{
    public class StopWatch : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the StopWatch class.
        /// </summary>
        public StopWatch()
          : base("BenchComponent", "StopWatch",
              "Returns the runtimes of all its inputs on any recompute.",
              "Impala", "Benchmarking")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Input", "I", "Input streams from components to measure", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddIntegerParameter("Runtime", "T", "Runtime in ms from each run", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var inParam = Params.Input[0];
            var doc = this.OnPingDocument();
            var comps = doc.Objects.Select(obj => (obj as GH_Component)).Where(c => c != null);
            var parameters = comps.Where(comp => comp.Params.Output.FirstOrDefault(p => (p != inParam) && inParam.DependsOn(p)) != null);
            var result = parameters.Select(p => p.ProcessorTime.TotalMilliseconds).Sum();

            DA.SetData(0, result);
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
                return Impala.Properties.Resources.__0001_Stopwatch;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("32115A9B-E4DB-43B2-AFE6-B3DB81DAA9A0"); }
        }
    }

    public class GroupStopWatch : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ImpalaTest class.
        /// </summary>
        public GroupStopWatch()
          : base("BenchGroup", "GStopWatch",
              "Returns the runtimes of all components in its group.",
              "Impala", "Benchmarking")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Reset", "R", "Recompute after this input", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddIntegerParameter("Runtime", "T", "Runtime in ms from each run", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var doc = OnPingDocument();
            
            var source = doc.Objects.Where(o => o is GH_Group).Select(o => o as GH_Group);
            var collection = source.Where(g => g.Objects().Contains(this));
            double result = 0;

            if (collection.Count() == 0)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Object must be in a group!");
                DA.SetData(0, result);
                return;
            }
            var comps = collection.SelectMany(g => g.Objects()).Select(c => c as GH_Component).Where(c => c != null);
            var singleCount = new HashSet<GH_Component>(comps);

            result = singleCount.Select(p => p.ProcessorTime.TotalMilliseconds).Sum();
            DA.SetData(0, result);
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
                return Impala.Properties.Resources.__0000_GStopwatch;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("1F21A3A5-1304-48F8-B1BD-93FF794150D1"); }
        }
    }
}
