using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StaticMembersAndNamespaces
{
    static class Storage
    {
        public static void SavePathToFile(string filePath, string pathOfPoints)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(pathOfPoints);
            }
        }

        public static Path3D LoadPathFromFile(string filePath)
        {
            Path3D pathOfPoints = new Path3D();
            List<Point3D> points = new List<Point3D>();
            
            using (StreamReader reader = new StreamReader(filePath))
            {
                List<double> coordinates = new List<double>();
                int counter = 0;
                string line = reader.ReadLine();
                string CoordPattern = @"(?:[xyz]\s*=\s*)(\d+\.?\d*)";
                Regex regex = new Regex(CoordPattern);

                while (line != null)
                {
                    if (regex.IsMatch(line))
                    {
                        //MatchCollection matches = Regex.Matches(line, CoordPattern);
                        Match match = Regex.Match(line, CoordPattern);
                        //if (matches.Count == 3)
                        //{
                        //    double x = Double.Parse(matches[0].Groups[1].Value);
                        //    double y = Double.Parse(matches[1].Groups[1].Value);
                        //    double z = Double.Parse(matches[2].Groups[1].Value);
                        //    Point3D point = new Point3D(x, y, z);
                        //    points.Add(point);
                        //}

                        coordinates.Add(Double.Parse(match.Groups[1].Value));
                        counter++;
                        if (counter == 3)
                        {
                            Point3D point = new Point3D(coordinates[0], coordinates[1], coordinates[2]);
                            points.Add(point);
                            counter = 0;
                            coordinates.Clear();
                        }
                    }

                    line = reader.ReadLine();
                }
            }
            pathOfPoints.AddPoints(points.ToArray());
            return pathOfPoints;
        }
    }
}
