using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMembersAndNamespaces
{
    class Path3D
    {
        private readonly List<Point3D> sequenceOfPoints = new List<Point3D>();

        public Path3D(params Point3D[] points)
        {
            this.AddPoints(points);
        }

        public List<Point3D> SequenceOfPoints
        {
            get { return this.sequenceOfPoints; }

            //set
            //{
            //    if (value == null)
            //    {
            //        throw new ArgumentException("The sequence of points cannot be empty!");
            //    }

            //    this.sequenceOfPoints = value;
            //}
        }

        public void AddPoints(Point3D[] points)
        {
            foreach (var point in points)
            {
                this.SequenceOfPoints.Add(point);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.SequenceOfPoints.Count; i++)
            {
                sb.AppendFormat("Point {0}:\nx = {1}\ny = {2}\nz = {3}\n", i + 1, this.SequenceOfPoints[i].XCoordinate,
                    this.SequenceOfPoints[i].YCoordinate, this.SequenceOfPoints[i].ZCoordinate);
            }
            return sb.ToString();
        }
    }
}
