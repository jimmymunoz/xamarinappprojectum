using SeniorAssistance.Database;
using SeniorAssistance.Model;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SeniorAssistance
{
	public partial class MyInformationPage : ContentPage
	{
        UserDatabase database;
        public MyInformationPage()
		{
            InitializeComponent();
            database = new UserDatabase();

            BtnSave.Clicked += async (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(Firstname.Text) || string.IsNullOrWhiteSpace(Lastname.Text) || string.IsNullOrWhiteSpace(Phone.Text))
                    return;
                
				User item = new User
                {
                    Firstname = Firstname.Text,
                    Lastname = Lastname.Text,
                    Phone = Phone.Text,
                    Adresse = Adresse.Text,
                };
                

                if (!string.IsNullOrWhiteSpace(ID.Text))
                    item.ID = Int32.Parse(ID.Text);

                database.SaveItem(item);
                await Navigation.PushAsync(new SettingsPage());
            };
            

            BtnCancel.Clicked += (sender, e) =>
            {
                Navigation.PopAsync();
            };
        }

    }
}
