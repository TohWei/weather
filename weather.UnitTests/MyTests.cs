using System;
using NUnit.Framework;
using weather.Manager;
using weather.PageModels;
using FreshMvvm;
using Moq;
using System.Threading.Tasks;
using weather.Models;

namespace weather.UnitTests
{
	[TestFixture]
	public class MyTests
	{
		LandingPageModel landingPageModel;

		[SetUp]
		public void SetUp()
		{
			Xamarin.Forms.Mocks.MockForms.Init();

			LandingPageCreation();
		}

		public void LandingPageCreation()
		{
			landingPageModel = new LandingPageModel()
			{
				CityName = "London"
			};
		}



		[Test]
		public void TestCityName()
		{
			Assert.AreEqual("London", landingPageModel.CityName);
		}

        [Test]
        public async Task TestWeatherManager(){

            string action = "London";

            //arrange
            var weatherManagerMock = new Mock<IWeatherManager>();
            var weatherDetailPageModel = new WeatherDetailPageModel(weatherManagerMock.Object);

            //act
            await weatherManagerMock.Object.GetWeatherData(action);

           
            //assert
            weatherManagerMock.Verify(q => q.GetWeatherData(It.IsAny<string>()));
        }

		[Test]
		public async Task TestCommandBtnSaveFavouriteCity()
		{
			var app = new App();
			app.Properties["FavCity"] = landingPageModel.CityName;
			await app.SavePropertiesAsync();

			app = new App();
			Assert.AreEqual(landingPageModel.CityName, app.Properties["FavCity"]);
		}

	}

}
