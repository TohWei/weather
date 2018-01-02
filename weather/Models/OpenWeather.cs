using System;
using System.Collections.Generic;

namespace weather.Models
{
    public class OpenWeather
    {
        public string Cod { get; set; }

        public string Message { get; set;}

        public string Cnt { get; set;}

        public List<WeatherDetail> List { get; set;}

        public City City
        {
            get;
            set;
        }
    }

    public class WeatherDetail{
        public long Dt
        {
            get;
            set;
        }

        public Main Main
        {
            get;
            set;
        }

        public List<Weather> Weather
        {
            get;
            set;
        }

        public Clouds Clouds
        {
            get;
            set;
        }

        public Wind Wind
        {
            get;
            set;
        }

        public Sys Sys
        {
            get;
            set;
        }

        public DateTime Dt_txt
        {
            get;
            set;
        }
    }

    public class Main{
        public float Temp
        {
            get;
            set;
        }

        public float Temp_min
        {
            get;
            set;
        }

        public float Temp_max
        {
            get;
            set;
        }
      
        public float Pressure
        {
            get;
            set;
        }
    
        public float Sea_level
        {
            get;
            set;
        }

        public float Gmd_level
        {
            get;
            set;
        }

        public float Humidity
        {
            get;
            set;
        }

        public float Temp_kf
        {
            get;
            set;
        }
    }


    public class Weather{
        public long Id
        {
            get;
            set;
        }

        public string Main
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Icon
        {
            get;
            set;
        }
    }

    public class Clouds{
        public int All
        {
            get;
            set;
        }
    }

    public class Wind{
        public float Speed
        {
            get;
            set;
        }

        public float Degree
        {
            get;
            set;
        }
    }


    public class Sys{
        public string Pod
        {
            get;
            set;
        }
    }


    public class City{
        public long Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Coord Coord
        {
            get;
            set;
        }

        public string Country
        {
            get;
            set;
        }

    }

    public class Coord{
        public float Lat
        {
            get;
            set;
        }

        public float Lon
        {
            get;
            set;
        }
    }
}

