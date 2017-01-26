using SeniorAssistance.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SeniorAssistance
{
    public partial class SettingsBankPage : ContentPage
    {
        public SettingsBankPage()
        {
            InitializeComponent();

            var tapImagebtnBNPParibas = new TapGestureRecognizer();
            tapImagebtnBNPParibas.Tapped += clickImageBnp;
            btnBNPParibas.GestureRecognizers.Add(tapImagebtnBNPParibas);

            var tapImageCréditagricole = new TapGestureRecognizer();
            tapImageCréditagricole.Tapped += clickImageCreditagricole;
            btnCréditagricole.GestureRecognizers.Add(tapImageCréditagricole);

            var tapImageSociétégénérale = new TapGestureRecognizer();
            tapImageSociétégénérale.Tapped += clickImageSocietegenrale;
            btnSociétégénérale.GestureRecognizers.Add(tapImageSociétégénérale);

            var tapImageCréditmutuelCIC = new TapGestureRecognizer();
            tapImageCréditmutuelCIC.Tapped += clickImageCréditmutuelCIC;
            btnCréditmutuelCIC.GestureRecognizers.Add(tapImageCréditmutuelCIC);
            
            var tapImagebtnBPCE = new TapGestureRecognizer();
            tapImagebtnBPCE.Tapped += clickImagbtnBPCE;
            btnBPCE.GestureRecognizers.Add(tapImagebtnBPCE);
           
            var tapImagebtnLaPoste = new TapGestureRecognizer();
            tapImagebtnLaPoste.Tapped += clickImagetnLaPoste;
            btnLaPoste.GestureRecognizers.Add(tapImagebtnLaPoste);

        }

        void clickImageBnp(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebViewInternet("https://group.bnpparibas/","Acceder a mon Compte"));
        }

        void clickImageCreditagricole(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebViewInternet("https://www.credit-agricole.com/", "Acceder a mon Compte"));
        }

        void clickImageSocietegenrale(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebViewInternet("https://www.societegenerale.com/fr/accueil", "Acceder a mon Compte"));
        }

        void clickImagbtnBPCE(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebViewInternet("http://www.groupebpce.fr/", "Acceder a mon Compte"));
        }


        void clickImageCréditmutuelCIC(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebViewInternet("https://www.creditmutuel.fr/groupe/fr/index.html", "Acceder a mon Compte"));
        }

        void clickImagetnLaPoste(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebViewInternet("http://www.laposte.fr/particulier", "Acceder a mon Compte"));
        }

    }
}
