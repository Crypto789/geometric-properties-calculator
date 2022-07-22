using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape_GEO_Calculator
{
    class Square
    {
        //Private variables for each of the properties of a square
        private double _SquareArea;
        private double _SquarePerimeter;
        private double _SquareCentroid_X;
        private double _SquareCentroid_Y;

        //Public variables for each of the properties of a square
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("CenterX")]
        public double CenterX { get; set; }
        [JsonProperty("CenterY")]
        public double CenterY { get; set; }
        [JsonProperty("SideLength")]
        public double SideLength { get; set; }
        [JsonProperty("Orientation")]
        public double Orientation { get; set; }
        //[JsonProperty("Parimeter")]
        //public double Parimeter { get { return _SquarePerimeter; } }
        //[JsonProperty("Area")]
        //public double Area { get { return _SquareArea; } }
        //[JsonProperty("Centroid X")]
        //public double Centroid_X { get { return _SquareCentroid_X; } }
        //[JsonProperty("Centroid Y")]
        //public double Centroid_Y { get { return _SquareCentroid_Y; } }

        //public Square()
        //{
        //    _SquareArea = 0.0;
        //    _SquareCentroid_X = 0.0;
        //    _SquareCentroid_Y = 0.0;
        //    _SquarePerimeter = 0.0;
        //}
        //public Square(double area, double perimeter, double X, double Y)
        //{
        //    this._SquareArea = area;
        //    this._SquarePerimeter = perimeter;
        //    this._SquareCentroid_X = X;
        //    this._SquareCentroid_Y = Y;
        //}
        //~Square() { }
    }

}
