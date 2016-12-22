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
		CrudDatabase database;

		ObservableCollection<ITable> ListContacts { get; set; }

		public ConfigContactsPage()
		{
			database = new ConctactDatabase();
			InitializeComponent();

			ListContacts = new ObservableCollection<ITable>();
			ContactsView.ItemsSource = ListContacts;

			btnAdd.Clicked += (sender, e) =>
			{
				Navigation.PushAsync(new ContactsFromPage());
			};

			ContactsView.ItemSelected += (sender, e) =>
			{
				if (e.SelectedItem != null)
				{
					var contact = e.SelectedItem as Contact;
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
			var items = (from i in database.GetItems<Contact>()
			             select i);

			foreach (var item in items)
			{
				ListContacts.Add(item);
			}
		}
	}
}
