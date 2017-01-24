using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SeniorAssistance
{
	public partial class HospitalsPage : ContentPage
	{
		public HospitalsPage()
		{
			InitializeComponent();
			var map = new Map(
				MapSpan.FromCenterAndRadius(
					new Position(37, -122), Distance.FromMiles(0.3)))
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
			
				
		}
	}
}
