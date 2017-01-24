using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SeniorAssistance
{
	public partial class HospitalsPage : ContentPage
	{
		//public List<CustomPin> CustomPins { get; set; }
		Map map;

		public HospitalsPage()
		{
			InitializeComponent();
			map = new Map(
				MapSpan.FromCenterAndRadius(
					new Position(43.6322777, 3.8621022), Distance.FromMiles(0.3)))
			{
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};



			var slider = new Slider(1, 18, 1);
			slider.ValueChanged += (sender, e) =>
			{
				var zoomLevel = e.NewValue; // between 1 and 18
				var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
				map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
			};
			stackHospitals.Children.Add(map);
			stackHospitals.Children.Add(slider);

			//moveMapToCurrentPosition();

		}


		private void addMapPins() { 
			
			var position = new Position(43.6322777, 3.8621022); // Latitude, Longitude
			var pin = new Pin
			{
				Type = PinType.Place,
				Position = position,
				Label = "Cafet",
				Address = "La fac"
			};
			map.Pins.Add(pin);
		}

		private async Task<Map> moveMapToCurrentPosition()
		{
			try
			{
				var locator = CrossGeolocator.Current;
				locator.DesiredAccuracy = 50;


				var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

				Debug.WriteLine("Position Status: {0}", position.Timestamp);
				Debug.WriteLine("Position Latitude: {0}", position.Latitude);
				Debug.WriteLine("Position Longitude: {0}", position.Longitude);

				map.MoveToRegion(MapSpan.FromCenterAndRadius(
					new Position(position.Latitude, position.Longitude),
					Distance.FromMiles(1)));

			}
			catch (Exception ex)
			{
				Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
			}
			return map;

		}
	}
}
