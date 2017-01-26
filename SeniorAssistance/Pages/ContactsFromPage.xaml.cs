using SeniorAssistance.Database;
using SeniorAssistance.Model;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace SeniorAssistance
{
	public partial class ContactsFromPage : ContentPage
	{
        MedicamentHistoryDatabase database;

        public ContactsFromPage()
		{
			InitializeComponent();
            database = new MedicamentHistoryDatabase();
          
            BtnSave.Clicked += async (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(Firstname.Text) || string.IsNullOrWhiteSpace(Lastname.Text) || string.IsNullOrWhiteSpace(Phone.Text))
                return;

                string action = await DisplayActionSheet("Type Of this Contact", "Cancel", null, "Nurse", "Doctor", "Mother", "Sister", "Daughter", "Husband", "Son", "grandchild", "Other");
                Debug.WriteLine("Action: " + action);

                Contact item = new Contact
                {
                    Firstname = Firstname.Text,
                    Lastname = Lastname.Text,
                    Phone = Phone.Text,
					Urgence = Urgence.IsToggled

                };
                item.TypeContact = action;

                if (!string.IsNullOrWhiteSpace(ID.Text))
                item.ID = Int32.Parse(ID.Text);

                database.SaveItem(item);                
                await Navigation.PushAsync(new ConfigContactsPage());
            };
			
           BtnDelete.Clicked += async (sender, e) =>
            {
                /*
                    * Normalement :c'est comme ça,malheureusement la methode getitem cast le type de l'item 
                   Contact contactToDelete= database.GetItem<Contact>(Int32.Parse(ID.Text));
                   database.DeleteItem(item);*/ 

                var answer = await DisplayAlert("Exit", "Do you wan't to delet this Contact", "Yes", "No");
                if (answer)
                {
                  Contact item = new Contact
                  {
                    Firstname = Firstname.Text,
                    Lastname = Lastname.Text,
                    Phone = Phone.Text,
                };
                item.ID = Int32.Parse(ID.Text);
                database.Connection.Delete(item);

                await Navigation.PushAsync(new ConfigContactsPage());
                }            
            };

            BtnCancel.Clicked += (sender, e) =>
            {
                Navigation.PopAsync();
            };
        }

	}
}
