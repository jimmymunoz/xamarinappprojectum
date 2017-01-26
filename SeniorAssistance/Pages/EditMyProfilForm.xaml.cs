using SeniorAssistance.Database;
using SeniorAssistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SeniorAssistance.Pages
{
    public partial class EditMyProfilForm : ContentPage
    {
        UserDatabase database;
        public EditMyProfilForm()
        {

            InitializeComponent();

			database = new UserDatabase();
            InitializeComponent();

            var tapImageEditProfil = new TapGestureRecognizer();
            tapImageEditProfil.Tapped += saveChangeProfile;
            saveNewChange.GestureRecognizers.Add(tapImageEditProfil);
        }

        async void saveChangeProfile(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Firstname.Text) || string.IsNullOrWhiteSpace(Lastname.Text))
                return;
            User user = new User
            {
                Firstname = Firstname.Text,
                Lastname = Lastname.Text,
                Phone = Phone.Text,
                Adresse = Adresse.Text,
            };
            if (!string.IsNullOrWhiteSpace(ID.Text))
                user.ID = Int32.Parse(ID.Text);

            database.SaveItem(user);
            await Navigation.PushAsync(new ProfilPage());

        }
    }
}