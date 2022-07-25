// See https://aka.ms/new-console-template for more information
using System;
using Aspose.Cells;
using Aspose.Cells.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.IO;
using Shape_GEO_Calculator;
using CsvHelper;

namespace Shape_GEO_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            GeoCalculator geo = new GeoCalculator();
            string json = JsonConvert.SerializeObject(geo.MappingValues(), Formatting.Indented);
            Console.WriteLine(json);
            var obj = JsonConvert.DeserializeObject<ValuesMapper[]>(json);
            Console.WriteLine(obj);
            using (TextWriter writer = new StreamWriter("FinalResult.csv"))
            {
                using (var csv = new CsvWriter(writer, System.Globalization.CultureInfo.CurrentCulture))
                {
                    csv.WriteRecords(obj);
                }
            }
        }


    }
}