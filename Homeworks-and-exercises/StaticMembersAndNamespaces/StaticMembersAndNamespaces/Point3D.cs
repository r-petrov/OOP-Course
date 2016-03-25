using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMembersAndNamespaces
{
    class Point3D
    {
        private static readonly Point3D startingPoint = new Point3D(0, 0, 0);
        
        public Point3D(double x, double y, double z)
        {
            this.XCoordinate = x;
            this.YCoordinate = y;
            this.ZCoordinate = z;
        }

        public double XCoordinate { get; set; }

        public double YCoordinate { get; set; }

        public double ZCoordinate { get; set; }

        public static Point3D StartingPoint
        {
            get { return startingPoint; }
        }

        public override string ToString()
        {
            return String.Format("The current point has following coordinates:\nx = {0}\ny = {1}\nz = {2}",
                this.XCoordinate, this.YCoordinate, this.ZCoordinate);
        }
    }
}
