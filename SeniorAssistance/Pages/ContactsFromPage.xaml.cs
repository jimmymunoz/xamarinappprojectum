using SeniorAssistance.Database;
using SeniorAssistance.Model;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static Android.Resource;

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
                    
                    return;
                Contact item = new Contact
                {
                    Firstname = Firstname.Text,
                    Lastname = Lastname.Text,
                    Phone = Phone.Text,
                };
                if (! string.IsNullOrWhiteSpace(ID.Text))
                    item.ID = Int32.Parse(ID.Text);
                
                database.SaveItem(item);
                Navigation.PopAsync();
            };

			BtnCancel.Clicked += (sender, e) =>
			{
				Navigation.PopAsync();
			};
        }

	}
}
