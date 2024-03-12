using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net;
namespace WeatherLibraryBySadiel.Weather
{
    public class Weather
    {
        public string getCityCoord(string apiKey, string city)
        {
            var json = getWetherByCity(apiKey, city);
            var wether = JsonSerializer.Deserialize<WeatherData.root>(json);
            return JsonSerializer.Serialize(wether.coord);

        }
        public string getWetherByCity(string apiKey, string city) {
            using (WebClient web = new WebClient())
            {
                string url1 = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", city, apiKey);
                var json = web.DownloadString(url1);
                return json;
            }            
        }

        public string getForecastByCity(string apiKey, string city)
        {
            WeatherData.coord coord = JsonSerializer.Deserialize<WeatherData.coord>( getCityCoord(apiKey, city));
            return getForecastByCoord(apiKey, coord.lat, coord.lon);
                     
        }
        public string getForecastByCoord(string apiKey, double lat, double lon) 
        {
            using (WebClient web = new WebClient())
            {
                string url2 = string.Format("https://api.openweathermap.org/data/2.5/onecall?lat={0}&lon={1}&exclude=part&appid={2}&units=metric", (int)lat, (int)lon, apiKey);
                var json2 = web.DownloadString(url2);
                return json2;
            }
        }
    }
}
