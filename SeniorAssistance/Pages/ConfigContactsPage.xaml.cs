using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SeniorAssistance.Database;
using SeniorAssistance.Model;
using Xamarin.Forms;

namespace SeniorAssistance
{
    public partial class ConfigContactsPage : ContentPage
    {
        ContactDatabase database;
        ContactTypeDatabase databasetype;


        ObservableCollection<ContactsTypeContact> ListContacts { get; set; }

        public ConfigContactsPage()
        {
            database = new ContactDatabase();
            databasetype = new ContactTypeDatabase();
            InitializeComponent();
            ListContacts = new ObservableCollection<ContactsTypeContact>();
            ContactsView.ItemsSource = ListContacts;

            btnAdd.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ContactsFromPage());
            };

            ContactsView.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    var contact = e.SelectedItem as ContactDatabase;
					var secondPage = new ContactsFromPage();
                    secondPage.BindingContext = contact;
                    Navigation.PushAsync(secondPage);
                }
            };
            RefreshList();

        }

        private void RefreshList()
        {
            ListContacts.Clear();
            ContactsTypeContact itemListView = new ContactsTypeContact();

            var TypeContacts = (from i in databasetype.GetItems<ContactType>() select i).Distinct().ToList();
            var Contacts = (from j in database.GetItems<Contact>() select j).Distinct().ToList();


            foreach (var contact in Contacts)
            {
                itemListView.Lastname = contact.Lastname;
                itemListView.Firstname = contact.Firstname;
                itemListView.TypeContact = contact.TypeContact;
                itemListView.Phone = contact.Phone;
				//itemListView.Urgence = contact.Urgence;
                itemListView.Image = "family.png";
                foreach (var typeContact in TypeContacts)
                {
                    string c = contact.TypeContact;
                    string t = typeContact.Name;
					if ( c != null && t != null ) { 
						if (c.Equals(t))
	                    {
	                        itemListView.Image = typeContact.Image;
	                        break;
	                    }
					}
                }
                ListContacts.Add(itemListView);
            }
        }
    }
}