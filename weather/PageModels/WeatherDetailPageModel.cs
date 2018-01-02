using System;
using System.Linq;
using System.Threading.Tasks;
using PropertyChanged;
using weather.Manager;
using Xamarin.Forms;

namespace weather.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class WeatherDetailPageModel : FreshMvvm.FreshBasePageModel
    {
        IWeatherManager _weatherManager;

		public WeatherDetailPageModel(IWeatherManager weatherManager)
        {
            _weatherManager = weatherManager;
        }



        LandingPageModel landingPageModel;
        public override async void Init(object initData)
        {
            base.Init(initData);

            landingPageModel = initData as LandingPageModel;
            await GetWeather(landingPageModel.CityName);
        }

        public ImageSource ImageIconSource{ get;set; }

        public string WeatherDescription{ get; set;}

        public string TemperatureMain { get; set; }

        public string CityNameAndCountry { get; set; }

        public string TemperatureRange { get; set; }

        public string WindSpeed { get; set; }

        public string DateTime { get; set; }

        public string FavouriteCity { get; set; }


        public Command CommandBtnSaveFavouriteCity
        {
            get {
                return new Command(() =>
                {
                    App.Current.Properties["FavCity"] = landingPageModel.CityName;
                    CoreMethods.DisplayAlert("Favourite City","Favourite city set. So that it will be pre-populated on your next visit to the app.","OK");
                });
            }
        }



		public async Task GetWeather(string cityName)
		{
			var result = await _weatherManager.GetWeatherData(cityName);

			if (result.List != null && result.List.Any())
			{
				var detailList = result.List.FirstOrDefault();
				if (detailList.Weather != null && detailList.Weather.Any())
				{
                    CityNameAndCountry = string.Format("{0}, {1}", result.City.Name, result.City.Country);
					WeatherDescription = detailList.Weather.FirstOrDefault().Description;
					var icon = detailList.Weather.FirstOrDefault().Icon;
					ImageIconSource = ImageSource.FromUri(new Uri("http://openweathermap.org/img/w/" + icon + ".png"));

                    var celsius = KelvinToCelsius(detailList.Main.Temp).ToString("##.#");
                    TemperatureMain = string.Format("{0}'C", celsius);

                    var celsiusFrom = KelvinToCelsius(detailList.Main.Temp_min).ToString("##.#");
                    var celsiusTo = KelvinToCelsius(detailList.Main.Temp_max).ToString("##.#");
                    TemperatureRange = string.Format("Min: {0}'C ---  Max: {1}'C", celsiusFrom, celsiusTo);
                    WindSpeed = string.Format("Wind Speed: {0} meter/sec", detailList.Wind.Speed.ToString("##.#"));
                    DateTime = detailList.Dt_txt.ToString("R");
				}
			}
		}

		private static double KelvinToCelsius(double d, bool kelvin = true)
		{
			return kelvin ? (d - 273.15) : (d + 273.15);
		}
    }
}
