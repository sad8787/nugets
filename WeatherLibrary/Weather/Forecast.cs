using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLibraryBySadiel.Weather
{
    class Forecast
    {
        public class feels_like
        {
            public double day { get; set; }
            public double night { get; set; }
            public double eve { get; set; }
            public double morn { get; set; }
        }
        public class temp
        {
            public double day { get; set; }
            public double min { get; set; }
            public double max { get; set; }
            public double night { get; set; }
            public double eve { get; set; }
            public double morn { get; set; }

        }
        public class weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }

        }
        public class snow
        {
            public double _1h { get; set; }
        }
        public class current
        {
            public long dt { get; set; }
            public long sunrise { get; set; }
            public long sunset { get; set; }
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }
            public double dew_point { get; set; }
            public double uvi { get; set; }
            public double clouds { get; set; }
            public int visibility { get; set; }
            public double wind_speed { get; set; }
            public double wind_deg { get; set; }
            public double wind_gust { get; set; }
            public List<weather> weather { get; set; }
            public snow snow { get; set; }

        }

        public class daily
        {
            public long dt { get; set; }
            public long sunrise { get; set; }
            public long sunset { get; set; }
            public long Daylight_hours()
            {
                return sunset - sunrise;
            }
            public long moonrise { get; set; }
            public long moonset { get; set; }
            public double moon_phase { get; set; }
            public temp temp { get; set; }
            public feels_like feels_Like { get; set; }
            public double Temperature_difference_at_night()
            {
                double difference = feels_Like.night - temp.night;
                if (difference < 0)
                    return difference * -1;
                return difference;
            }
            public double pressure { get; set; }
            public double humidity { get; set; }
            public double dew_point { get; set; }
            public double wind_speed { get; set; }
            public double wind_deg { get; set; }
            public double wind_gust { get; set; }
            public List<weather> weather { get; set; }
            public int clouds { get; set; }
            public double pop { get; set; }
            public double snow { get; set; }
            public double uvi { get; set; }

        }

        public class root
        {
            public int lat { get; set; }
            public int lon { get; set; }
            public string timezone { get; set; }
            public int timezone_offset { get; set; }
            public current current { get; set; }
            public List<daily> daily { get; set; }
            public void Temperature_difference_at_night(out double differenceTemp, out long dt)
            {
                differenceTemp = 999999999;
                dt = 0;
                foreach (var a in daily)
                {
                    if (a.Temperature_difference_at_night() < differenceTemp)
                    {
                        differenceTemp = a.Temperature_difference_at_night();
                        dt = a.dt;
                    }
                }
            }
            public void Day_with_mor_light(out long daylight_hours, out long dt)
            {
                daylight_hours = 0;
                dt = 0;
                int cont = 0;
                foreach (var a in daily)
                {
                    if (cont == 4)
                        if (a.Daylight_hours() > daylight_hours)
                        {
                            daylight_hours = a.Daylight_hours();
                            dt = a.dt;
                        }
                    cont++;
                }
            }



        }
    }
}
