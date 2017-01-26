using SeniorAssistance.Database;
using SeniorAssistance.Model;
using SeniorAssistance.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace SeniorAssistance
{
	public partial class SettingsPage : ContentPage
	{
        UserDatabase database;

        public SettingsPage()
		{
			InitializeComponent();
            database = new UserDatabase();
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
            
            int user  = database.GetCount<User>();

            if (user.Equals(0))
            {
                Navigation.PushAsync(new MyInformationPage());
            }
            else
            {
                Navigation.PushAsync(new ProfilPage());
            }
            
		}

		void clickImageContacts(object sender, EventArgs e)
		{
			Navigation.PushAsync(new ConfigContactsPage());
		}

		void clickImageBank(object sender, EventArgs e)
		{
			Navigation.PushAsync(new SettingsBankPage());
		}

	}
}
