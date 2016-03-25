using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMembersAndNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var pointOne = new Point3D(2, 5, 8);
            Console.WriteLine(pointOne + "\n");

            var pointTwo = new Point3D(2.3, 5.8, 8);
            Console.WriteLine(pointTwo + "\n");

            //Console.WriteLine(DistanceCalculator.CalculateDistanceBetween3DPoints(pointOne, pointTwo));
            //Console.WriteLine(DistanceCalculator.CalculateDistanceBetween3DPoints(pointTwo, pointOne));

            var pathOfPoints = new Path3D(pointOne, pointTwo);
            Storage.SavePathToFile(@".../.../pathOfPoints.txt", 
                pathOfPoints.ToString());
            Console.WriteLine(Storage.LoadPathFromFile(@".../.../pathOfPoints.txt"));
        }
    }
}
