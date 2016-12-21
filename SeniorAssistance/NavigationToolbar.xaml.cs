using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SeniorAssistance
{
	public partial class NavigationToolbar : StackLayout
	{
		public NavigationToolbar()
		{
			InitializeComponent();
			//http://www.c-sharpcorner.com/UploadFile/e04e9a/xamarin-forms-image-button-recipe/
			//Creating TapGestureRecognizers  
			var tapImageHome = new TapGestureRecognizer();
			//Binding events  
			tapImageHome.Tapped += clickImageHome;
			//Associating tap events to the image buttons  
			btnHome.GestureRecognizers.Add(tapImageHome);

			var tapImageSettings = new TapGestureRecognizer();
			//Binding events  
			tapImageSettings.Tapped += clickImageSettings;
			//Associating tap events to the image buttons  
			btnSettings.GestureRecognizers.Add(tapImageSettings);

			var tapImageCall = new TapGestureRecognizer();
			//Binding events  
			tapImageCall.Tapped += clickImageCall;
			//Associating tap events to the image buttons  
			btnCall.GestureRecognizers.Add(tapImageCall);
		}

		void clickImageHome(object sender, EventArgs e)
		{
			Navigation.PushAsync(new HomeLayoutPage());
		}

		void clickImageSettings(object sender, EventArgs e)
		{
			Navigation.PushAsync(new SettingsPage());
		}

		void clickImageCall(object sender, EventArgs e)
		{
			//Navigation.PushAsync(new PersonsPage());
		}
	}
}
