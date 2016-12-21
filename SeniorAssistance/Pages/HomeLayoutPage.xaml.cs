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

			var tapImageMedicaments = new TapGestureRecognizer();
			tapImageMedicaments.Tapped += clickImageMedicaments;
			btnHospital.GestureRecognizers.Add(tapImageMedicaments);


		}

		void clickImageInternet(object sender, EventArgs e)
		{
			//Navigation.PushAsync(new HomeLayoutPage());
		}

		void clickImageMedicaments(object sender, EventArgs e)
		{
			//Navigation.PushAsync(new MedicamentsPage());
		}




	}
}
