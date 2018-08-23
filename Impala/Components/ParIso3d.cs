using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impala.Components
{
    class ParIso3d
    {
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
