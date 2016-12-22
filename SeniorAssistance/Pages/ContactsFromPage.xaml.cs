using SeniorAssistance.Database;
using SeniorAssistance.Model;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SeniorAssistance
{
	public partial class ContactsFromPage : ContentPage
	{
		CrudDatabase database;

        public ContactsFromPage()
		{
			InitializeComponent();
            database = new ConctactDatabase();
          
            BtnSave.Clicked += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(Firstname.Text) || string.IsNullOrWhiteSpace(Lastname.Text) || string.IsNullOrWhiteSpace(Phone.Text))
                    //DisplayAlert(" ", " + " delete context action", "OK");
                    return;
                   
                database.SaveItem(new Contact
                {
                    ID = ID.Text,
					Firstname = Firstname.Text,
                    Lastname = Lastname.Text,
                    Phone = Phone.Text,              
                });
                Navigation.PopAsync();
            };

			BtnCancel.Clicked += (sender, e) =>
			{
				Navigation.PopAsync();
			};
        }

	}
}
