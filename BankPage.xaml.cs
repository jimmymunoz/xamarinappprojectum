using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SeniorAssistance.Pages
{
    public partial class BankPage : ContentPage
    {
        public BankPage()
        {
            InitializeComponent();
            var tapImageInternet = new TapGestureRecognizer();
            tapImageInternet.Tapped += clickImageInternet;
            btnBNPParibas.GestureRecognizers.Add(tapImageInternet);

            var tapImageHospital = new TapGestureRecognizer();
            tapImageHospital.Tapped += clickImageHospital;
            btnCréditagricole.GestureRecognizers.Add(tapImageHospital);

            var tapImageMedicaments = new TapGestureRecognizer();
            tapImageMedicaments.Tapped += clickImageMedicaments;
            btnSociétégénérale.GestureRecognizers.Add(tapImageMedicaments);


            var tapImageGames = new TapGestureRecognizer();
            tapImageGames.Tapped += clickImageGames;
            btnCréditmutuelCIC.GestureRecognizers.Add(tapImageGames);


        }

        void clickImageInternet(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebViewInternet("https://www.google.fr/"));
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
            Navigation.PushAsync(new GamesPage());
        }




    }
}
