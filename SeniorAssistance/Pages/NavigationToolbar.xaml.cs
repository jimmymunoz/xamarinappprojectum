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
			var tapImageHome = new TapGestureRecognizer();
			tapImageHome.Tapped += clickImageHome;
			btnHome.GestureRecognizers.Add(tapImageHome);

			var tapImageSettings = new TapGestureRecognizer();
			tapImageSettings.Tapped += clickImageSettings;
			btnSettings.GestureRecognizers.Add(tapImageSettings);

			var tapImageCall = new TapGestureRecognizer();
			tapImageCall.Tapped += clickImageCall;
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
			Navigation.PushAsync(new ContactsPage());
			//Navigation.PushAsync(new ContactPage());
		}
	}
}
