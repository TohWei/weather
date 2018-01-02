using System;
using FreshMvvm;
using weather.Manager;
using weather.PageModels;
using Xamarin.Forms;

namespace weather
{
    public class App : Application
    {
        public App()
        {
            //Setup dependency injection - IOC
            SetupIOC();

            var page  = FreshMvvm.FreshPageModelResolver.ResolvePageModel<LandingPageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }

        void SetupIOC()
        {
            FreshIOC.Container.Register<IWeatherManager, WeatherManager>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
