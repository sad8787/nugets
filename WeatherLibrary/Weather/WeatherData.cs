using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLibraryBySadiel.Weather
{
    class WeatherData
    {
        public class coord
        {
            public double lon { get; set; }//longitude
            public double lat { get; set; }//latitude
        }
        public class root //master class
        {
            public coord coord { get; set; }
            public string name { get; set; }
            public int cod { get; set; }


        }
    }
}
