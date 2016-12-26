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
            Navigation.PushAsync(new WebViewInternet("https://group.bnpparibas/"));
        }

        void clickImageCreditagricole(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebViewInternet("https://www.credit-agricole.com/"));
        }

        void clickImageSocietegenrale(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebViewInternet("https://www.societegenerale.com/fr/accueil"));
        }

        void clickImagbtnBPCE(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new WebViewInternet("http://www.groupebpce.fr/"));
        }


        void clickImageCréditmutuelCIC(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebViewInternet("https://www.creditmutuel.fr/groupe/fr/index.html"));
        }

        void clickImagetnLaPoste(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebViewInternet("http://www.laposte.fr/particulier"));
        }

    }
}
