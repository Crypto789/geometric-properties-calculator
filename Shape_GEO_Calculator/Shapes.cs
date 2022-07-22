using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Shape_GEO_Calculator;

namespace Shape_GEO_Calculator
{
   
    public partial class Shapes
    {
        public List<Square> Squares { get; set; }

        public List<Ellipse> Ellipses { get; set; }

        public List<Circle> Circles { get; set; }

        public List<EquilateralTriangle> EquilateralTriangles { get; set; }

        public List<Polygon> Polygons { get; set; }

    }

    public partial class Square
    {
        public double _perimeter = 0;
        public double _area = 0;

        public long Id { get; set; }

        public double CenterX { get; set; }

        public double CenterY { get; set; }

        public double SideLength { get; set; }

        public double Orientation { get; set; }

        public double Area { get { return _area; } set { _area = value; } }

        public double Perimeter { get { return _perimeter; } set { _perimeter = value; } }
    }

    public partial class Circle
    {
        public double _perimeter=0;
        public double _area=0;

        public long Id { get; set; }

        public double CenterX { get; set; }

        public double CenterY { get; set; }

        public double Radius { get; set; }

        public double Area { get { return _area; } set { _area = value; } }

        public double Perimeter { get { return _perimeter; } set { _perimeter = value; } }
    }

    public partial class Ellipse
    {
        public double _perimeter = 0;
        public double _area = 0;

        public long Id { get; set; }

        public double CenterX { get; set; }

        public double CenterY { get; set; }

        public double R1 { get; set; }

        public double R2 { get; set; }

        public double Orientation { get; set; }

        public double Area { get { return _area; } set { _area = value; } }

        public double Perimeter { get { return _perimeter; } set { _perimeter = value; } }
    }

    public partial class EquilateralTriangle
    {
        public double _perimeter = 0;
        public double _area = 0;

        public long Id { get; set; }

        public double CenterX { get; set; }

        public double CenterY { get; set; }

        public double SideLength { get; set; }

        public double Orientation { get; set; }

        public double Area { get { return _area; }set { _area = value; } }

        public double Perimeter { get { return _perimeter; } set { _perimeter = value; } }
    }

    public partial class Polygon 
    {
        public double _perimeter = 0;
        public double _area = 0;

        public long Id { get; set; }

        public List<double> XCoordinates { get; set; }

        public List<double> YCoordinates { get; set; }

        public double Area { get { return _area; } set { _area = value; } }

        public double Perimeter { get { return _perimeter; } set { _perimeter = value; } }
    }
    public partial class ValuesMapper {
        public long Id { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }
        
    }
    public partial class Shapes
    {
        public static Shapes FromJson(string json) => JsonConvert.DeserializeObject<Shapes>(json, Shape_GEO_Calculator.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Shapes self) => JsonConvert.SerializeObject(self, Shape_GEO_Calculator.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

