using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericClass;

namespace _3DSpace
{
    public class Path
    {
        public List<Point3D> PointSequence { get; set; }

        public Path()
        {
            this.PointSequence = new List<Point3D>();
        }

        public void AddPoint(Point3D newPoint)
        {
            this.PointSequence.Add(newPoint);
        }
        public void RemovePoint(int indexOfPoit)
        {
            this.PointSequence.Remove(PointSequence[indexOfPoit-1]);
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            for (int i = 0; i < PointSequence.Count; i++)
            {
                output.AppendFormat("{0}. X({1}), Y({2}), Z({3})\n", i + 1, PointSequence[i].X, PointSequence[i].Y, PointSequence[i].Z);
            }

            return output.ToString().TrimEnd('\n');
        }
    }
}
