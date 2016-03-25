using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMembersAndNamespaces
{
    static class DistanceCalculator
    {
        public static double CalculateDistanceBetween3DPoints(Point3D pointOne, Point3D pointTwo)
        {
            double distance = Math.Sqrt(Math.Pow((pointTwo.XCoordinate - pointOne.XCoordinate), 2) +
                Math.Pow((pointTwo.YCoordinate - pointOne.YCoordinate), 2) + Math.Pow((pointTwo.ZCoordinate - pointOne.ZCoordinate), 2));

            return distance;
        }
    }
}
