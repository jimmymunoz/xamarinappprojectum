using SeniorAssistance.Database;
using SeniorAssistance;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SeniorAssistance
{
	public partial class HomeLayoutPage : ContentPage
	{
   
        public HomeLayoutPage()
		{
			InitializeComponent();

            var tapImageInternet = new TapGestureRecognizer();
			tapImageInternet.Tapped += clickImageInternet;
			btnInternet.GestureRecognizers.Add(tapImageInternet);

			var tapImageHospital = new TapGestureRecognizer();
			tapImageHospital.Tapped += clickImageHospital;
			btnHospital.GestureRecognizers.Add(tapImageHospital);

			var tapImageMedicaments = new TapGestureRecognizer();
			tapImageMedicaments.Tapped += clickImageMedicaments;
			btnMedicaments.GestureRecognizers.Add(tapImageMedicaments);
            

            var tapImageGames = new TapGestureRecognizer();
			tapImageGames.Tapped += clickImageGames;
			btnGames.GestureRecognizers.Add(tapImageGames);


		}

		void clickImageInternet(object sender, EventArgs e)
		{
			Navigation.PushAsync(new WebViewInternet("https://www.google.fr/","Internet"));
		}

		void clickImageHospital(object sender, EventArgs e)
		{
			Navigation.PushAsync(new HospitalsPage());
		}

		void clickImageMedicaments(object sender, EventArgs e)
		{
			Navigation.PushAsync(new MedicamentsPage());
		}

		void clickImageGames(object sender, EventArgs e)
		{
			Navigation.PushAsync(new WebViewInternet("http://fr.ibraining.com/memorize/","Jeux de mémorisation"));
		}




	}
}
