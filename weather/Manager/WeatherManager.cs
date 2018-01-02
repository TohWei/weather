using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using weather.Models;

namespace weather.Manager
{
    public class WeatherManager : IWeatherManager
    {
        const string APIKey = "039f77bc3308c1ddbffbc450ab01439b";
        const string CityServiceEndPoint = "http://api.openweathermap.org/data/2.5/forecast?q={CITY}&APPID={APIKEY}";

        public WeatherManager()
        {
        }

        public async Task<OpenWeather> GetWeatherData(string cityName)
        {
            OpenWeather res = null;
            var url = CityServiceEndPoint.Replace("{CITY}", cityName).Replace("{APIKEY}", APIKey);
            var targetUrl = new Uri(url);

            using (var httpClient = new HttpClient()){
                HttpResponseMessage response = await httpClient.GetAsync(targetUrl);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<OpenWeather>(result);
                }
            }

            return res;
        }
    }
}
