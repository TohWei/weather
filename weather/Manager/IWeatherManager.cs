using System;
using System.Threading.Tasks;
using weather.Models;

namespace weather.Manager
{
    public interface IWeatherManager
    {
        Task<OpenWeather> GetWeatherData(string cityName);
    }
}
