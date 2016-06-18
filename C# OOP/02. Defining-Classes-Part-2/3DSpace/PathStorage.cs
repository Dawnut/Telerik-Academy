using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericClass;

namespace _3DSpace
{
    public class PathStorage
    {
        public static void SavePath (Path Path)
        {
            var writer = new StreamWriter(@"..\..\paths.txt", false);

            using (writer)
            {
                foreach (var item in Path.PointSequence)
                {
                    writer.WriteLine("{0} {1} {2}", item.X, item.Y, item.Z);
                    
                }
                writer.Close();
            }
        }

        public static Path LoadPath()
        {
            var reader = new StreamReader(@"..\..\paths.txt");
            var path = new Path();

            using (reader)
            {
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    double[] coordinates = currentLine.Split(new char[] {' '}).Select(x => double.Parse(x)).ToArray();
                    path.AddPoint(new Point3D(coordinates[0], coordinates[1], coordinates[2]));
                    currentLine = reader.ReadLine();
                }
                reader.Close();
            }
            return path;
        }
    }
}
