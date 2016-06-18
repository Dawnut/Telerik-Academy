using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DSpace;
using GenericClass;
using Matrix;
using Attribute;

namespace Defining_Classes_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3D Space tests -- 
            // Uncomment to test functionality 

             var point = new Point3D(1, 1, 1);
             var startPoint = Point3D.StartingPoint;
             var distance = Distance.Calculate(startPoint, point);
             Console.WriteLine("Distance: {0:F2}", distance);
             
             var path = new Path();
             path.AddPoint(new Point3D(2, 3, 6));
             path.AddPoint(new Point3D(-1, 2, 4));
             path.AddPoint(new Point3D(5, 1, 5));
             
             PathStorage.SavePath(path);
             Console.WriteLine(PathStorage.LoadPath());

            //------------------------------------------------------------------------

            // GenericClass tests --
            // Uncomment to test functionality 

            // var list = new GenericList<int>(3);
            // 
            // list.Add(-5);
            // list.Add(10);
            // list.Add(15);
            // list.InsertAtGivenPosition(3, 20);
            // list.RemoveByIndex(3);
            //     // list.Clear();
            // 
            // Console.WriteLine("First index: " + list[1]);
            // Console.WriteLine("Min: " + list.Min());
            // Console.WriteLine("Max: " + list.Max());
            // Console.WriteLine(list);

            //------------------------------------------------------------------------

            // Matrix tests --
            // Uncomment to test functionality 


            // int row = 3, col = 3;
            // var firstMatrix = new Matrix<int>(row, col);
            // int counter = 1;
            // 
            // for (int i = 0; i < row; i++)
            // {
            //     for (int j = 0; j < col; j++)
            //     {
            //         firstMatrix[i, j] = counter;
            //         counter++;
            //     }
            // }
            // 
            // Console.WriteLine(firstMatrix);
            // 
            // row = 3; col = 3;
            // counter = 1;
            // var secondMatrix = new Matrix<int>(row, col);
            // 
            // for (int i = 0; i < row; i++)
            // {
            //     for (int j = 0; j < col; j++)
            //     {
            //         secondMatrix[i, j] = counter;
            //         counter++;
            //     }
            // }
            // 
            // Console.WriteLine(secondMatrix);
            // 
            // Console.WriteLine(firstMatrix + secondMatrix);
            // Console.WriteLine(firstMatrix - secondMatrix);
            // Console.WriteLine(firstMatrix * secondMatrix);
            // 
            // if (firstMatrix)
            // {
            //     Console.WriteLine("Non-zero matrix");
            // }
            // else
            // {
            //     Console.WriteLine("Zero matrix");
            // }

            //------------------------------------------------------------------------

            // Attribute tests --
            // Uncomment to test functionality 

            // Type type = typeof(Startup);
            // object[] allAttributes = type.GetCustomAttributes(false);
            // foreach (VersionAttribute versionAttribute in allAttributes)
            // {
            //     Console.WriteLine("Version {0}", versionAttribute.Version);
            // }
        }

        // [Version("1.00")]
        // public class Startup
        // {
        //     
        // }

        //------------------------------------------------------------------------

    }
}
