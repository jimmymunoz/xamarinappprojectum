using Java.Util;
using SeniorAssistance.Database;
using SeniorAssistance.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace SeniorAssistance
{
    public partial class ContactsPage : ContentPage
    {
        ContactDatabase databaseContact;
        ContactTypeDatabase databaseConntactType;
        ObservableCollection<ContactsTypeContact> ListContact { get; set; }
        ObservableCollection<ContactsTypeContact> liste { get; set; }

        public ContactsPage()
        {
            InitializeComponent();
            databaseContact = new ContactDatabase();
            databaseConntactType = new ContactTypeDatabase();
            ListContact = new ObservableCollection<ContactsTypeContact>();
            liste = new ObservableCollection<ContactsTypeContact>();
            ContactsViewAppel.ItemsSource = ListContact;

            RefreshList();
            ContactsViewAppel.ItemTapped += async (sender, args) =>
            {
                ContactsTypeContact tel = (ContactsTypeContact)args.Item;                
                var action = await DisplayActionSheet("ActionSheet: Do you want Call "+tel.Firstname+"?", "Cancel","Yes");
                    if (action.Equals("Yes"))
                    {
                        Device.OpenUri(new Uri("tel:"+tel.Phone));
                    }      
            };
        }
       
        private void RefreshList()
        {
            ListContact.Clear();
            ContactsTypeContact itemListView = new ContactsTypeContact();
            
            var TypeContacts = (from i in databaseConntactType.GetItems<ContactType>() select i).Distinct().ToList();
            var Contacts = (from j in databaseConntactType.GetItems<Contact>() select j).Distinct().ToList();


            foreach (var contact in Contacts)
            {
                itemListView.Lastname = contact.Lastname;
                itemListView.Firstname = contact.Firstname;
                itemListView.TypeContact = contact.TypeContact;
                itemListView.Phone = contact.Phone;
                itemListView.Image = "family.png";
                foreach (var typeContact in TypeContacts)
                {
                    string c = contact.TypeContact;
                    string t = typeContact.Name;
                    if ( c.Equals(t) ) {
                        itemListView.Image = typeContact.Image;
                        break;                  
                    }
                }
                ListContact.Add(itemListView);
            } 

           
                                   
        }

    }
}
