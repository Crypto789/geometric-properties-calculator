using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shape_GEO_Calculator;

namespace Shape_GEO_Calculator
{
    public class GeoCalculator 
    {
        // helper variables
        double vertexes = 0;
        int length = 4;
        double Root = (float)Math.Sqrt(3) / 4;
        
        public List<double> SquareArea() {
            List<double> Values = new List<double>();
            using (StreamReader read = new StreamReader("Shapes-49464.json")) {
                string data = read.ReadToEnd();
                Shapes shapes = Shapes.FromJson(data);
                foreach (Square s in shapes.Squares) {
                    s._area = s.SideLength * 4;
                    Values.Add(s._area);
                }
                return Values;
            }
        }

        public List<double> SquarePerimeter() {
            List<double> Values = new List<double>();
            using (StreamReader read = new StreamReader("Shapes-49464.json"))
            {
                string data = read.ReadToEnd();
                Shapes shapes = Shapes.FromJson(data);
                foreach (Square s in shapes.Squares)
                {
                    s._perimeter = s.SideLength * s.SideLength;
                    Values.Add(s._perimeter);
                }
                return Values;
            }
        }

        public List<double> CircleArea() {
            List<double> Values = new List<double>();
            using (StreamReader read = new StreamReader("Shapes-49464.json"))
            {
                string data = read.ReadToEnd();
                Shapes shapes = Shapes.FromJson(data);
                foreach (Circle c in shapes.Circles)
                {
                    c._area = Math.Round(Math.PI * Math.Pow((c.Radius * 2), 2));
                    Values.Add(c._area);
                }
                return Values;
            }
        }

        public List<double> CirclePeriemeter() {
            List<double> Values = new List<double>();
            using (StreamReader read = new StreamReader("Shapes-49464.json"))
            {
                string data = read.ReadToEnd();
                Shapes shapes = Shapes.FromJson(data);
                foreach (Circle c in shapes.Circles)
                {
                    c._perimeter = Math.Round(Math.PI * (c.Radius * 2), 2);
                    Values.Add(c._perimeter);
                }
                return Values;
            }
        }
        //finding the area of ellipse
        public List<double> EllipseArea()
        {
            List<double> Values = new List<double>();
            using (StreamReader read = new StreamReader("Shapes-49464.json"))
            {
                string data = read.ReadToEnd();
                Shapes shapes = Shapes.FromJson(data);
                foreach (Ellipse e in shapes.Ellipses)
                {
                    e._area = e.R1 * e.R2 * 3.142;
                    Values.Add(e._area);
                }
                return Values;
            }
        }
        //finding the perimeter of ellipse
        public List<double> EllipsePerimeter()
        {
            List<double> Values = new List<double>();
            using (StreamReader read = new StreamReader("Shapes-49464.json"))
            {
                string data = read.ReadToEnd();
                Shapes shapes = Shapes.FromJson(data);
                foreach (Ellipse e in shapes.Ellipses)
                {
                    e._perimeter = Math.Sqrt((e.R1 * e.R1 + e.R2 * e.R2) / (1.0 * 2)) * 2.14 * 2;
                    Values.Add(e._perimeter);
                }
                return Values;
            }
        }
        //solving for PolygonArea using Shoelace formula
        public List<double> PolygonArea() {
            List<double> Values = new List<double>();
            int last = length - 1;
            using (StreamReader read = new StreamReader("Shapes-49464.json"))
            {
                string data = read.ReadToEnd();
                Shapes shapes = Shapes.FromJson(data);
                foreach (Polygon p in shapes.Polygons)
                {
                    for (int l = 0; l < length; l++)
                    {
                        vertexes += (p.XCoordinates[last] + p.XCoordinates[l]) * (p.YCoordinates[last] + p.YCoordinates[l]);
                        last = l;
                    }
                    p._area = Math.Abs(vertexes / 2.0);
                    Values.Add(p._area);
                }
                return Values;
            }
        }

        public void PolygonPerimeter() {
        }
        //getting the Area of Equilteral Triangle
        public List<double> EquilateralTriangleArea() {
            List<double> Values = new List<double>();
            using (StreamReader read = new StreamReader("Shapes-49464.json"))
            {
                string data = read.ReadToEnd();
                Shapes shapes = Shapes.FromJson(data);
                foreach (EquilateralTriangle ET in shapes.EquilateralTriangles)
                {
                    ET._area = ET.SideLength * Root * ET.SideLength;
                    Values.Add(ET._area);
                }
                return Values;
            }
        }
        //getting the Parimeter of Equilteral Triangle
        public List<double> EquilateralTrianglePerimeter() {
            List<double> Values = new List<double>();
            using (StreamReader read = new StreamReader("Shapes-49464.json"))
            {
                string data = read.ReadToEnd();
                Shapes shapes = Shapes.FromJson(data);
                foreach (EquilateralTriangle ET in shapes.EquilateralTriangles)
                {
                    ET._perimeter = (float)3 * ET.SideLength;
                    Values.Add(ET._perimeter);
                }
                return Values;
            }
        }
        //storing Parimeter
        public List<double> PerimeterValues() {
            List<double> Values = new List<double>();
            foreach (double Peri in SquarePerimeter()) { Values.Add(Peri); }
            foreach (double Peri in CirclePeriemeter()) { Values.Add(Peri); }
            foreach (double Peri in EllipsePerimeter()) { Values.Add(Peri);}
            foreach (double Peri in EquilateralTrianglePerimeter()) {Values.Add(Peri);}
            return Values;
        }
        //Storing all Area Values
        public List<double> AreaValues() {
            List<double> Values = new List<double>();
            foreach (double Area in SquareArea()) { Values.Add(Area); }
            foreach (double Area in CircleArea()) { Values.Add(Area); }
            foreach (double Area in EllipseArea()) { Values.Add(Area); }
            foreach (double Area in EquilateralTriangleArea()) { Values.Add(Area); }
            foreach (double Area in PolygonArea()) { Values.Add(Area); }
            return Values;
        }
        //Creating Objects parts of Json
        public List<ValuesMapper> MappingValues() {
            List<double> area = new List<double>();
            List<double> peri = new List<double>();
            List<ValuesMapper> objects = new List<ValuesMapper>();
            ValuesMapper  map = new ValuesMapper();
            foreach (double p in PerimeterValues()) { peri.Add(p); }
            foreach (double a in AreaValues()) { area.Add(a); }
            
            //using Perimeter Length to keep from going out of index
            for (var i = 1; i < peri.Count(); i++)
            {

                map = new ValuesMapper { Id = i, Area = area[i], Perimeter = peri[i] };
                objects.Add(map);
            }
            return objects;
        }

    }

}
