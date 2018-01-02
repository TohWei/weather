using System;
using Xamarin.Forms;

namespace weather.PageModels
{
    public class LandingPageModel : FreshMvvm.FreshBasePageModel
    {
        public LandingPageModel()
        {
        }

        public string CityName
        {
            get;
            set;
        }


        public Command CommandBtnCheckWeather{
            get {
                return new Command(async() =>
                {
                    if (string.IsNullOrEmpty((CityName)))
                    {
                        await CoreMethods.DisplayAlert("City Name", "Please provide a name of a city", "OK");
                    }
                    else
                    {
                        await CoreMethods.PushPageModel<WeatherDetailPageModel>(this);
                    }
                });
            }
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);


            if (App.Current.Properties.ContainsKey("FavCity") && App.Current.Properties["FavCity"] != null){
                CityName = App.Current.Properties["FavCity"].ToString();
            }else{
                CityName = "";
            }
        }
    }
}
