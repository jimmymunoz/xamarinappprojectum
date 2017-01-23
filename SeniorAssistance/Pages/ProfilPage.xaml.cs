using SeniorAssistance.Database;
using SeniorAssistance.Model;
using SeniorAssistance.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SeniorAssistance
{
    public partial class ProfilPage : ContentPage
    {
        UserDatabase database;
        IEnumerable<User> user;
        public ProfilPage()
        {
            database = new UserDatabase();
            InitializeComponent();
          
            user = database.GetItems<User>();
            /*Firstname.settext = items.Firstname;
            Lastname = items.Lastname;
            Phone = items.Phone;
            = items.Adresse;*/
            foreach ( var  us in user)
            {
                
                Firstname.Text = us.Firstname;
                Lastname.Text = us.Lastname;
                Phone.Text = us.Phone;
                Adresse.Text = us.Adresse;
                break;
            }

            var tapImageEditProfil = new TapGestureRecognizer();
            tapImageEditProfil.Tapped += editProfile;
            imageEditProfil.GestureRecognizers.Add(tapImageEditProfil);


        }
        void editProfile(object sender, EventArgs e)
        {
            User us =  user.First();
            var secondPage = new EditMyProfilForm();
            secondPage.BindingContext = us;
            Navigation.PushAsync(secondPage);
        }
    }
}
