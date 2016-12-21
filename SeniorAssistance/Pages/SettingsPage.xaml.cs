using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SeniorAssistance
{
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			InitializeComponent();

			var tapImageMyInformation = new TapGestureRecognizer();
			tapImageMyInformation.Tapped += clickImageMyInformation;
			btnMyInformation.GestureRecognizers.Add(tapImageMyInformation);

			var tapImageContacts = new TapGestureRecognizer();
			tapImageContacts.Tapped += clickImageContacts;
			btnContacts.GestureRecognizers.Add(tapImageContacts);

			var tapImageBank = new TapGestureRecognizer();
			tapImageBank.Tapped += clickImageBank;
			btnBank.GestureRecognizers.Add(tapImageBank);

		}

		void clickImageMyInformation(object sender, EventArgs e)
		{
			//Navigation.PushAsync(new SettingsPage());
		}

		void clickImageContacts(object sender, EventArgs e)
		{
			//Navigation.PushAsync(new MedicamentsPage());
		}

		void clickImageBank(object sender, EventArgs e)
		{
			//Navigation.PushAsync(new MedicamentsPage());
		}




	}
}
