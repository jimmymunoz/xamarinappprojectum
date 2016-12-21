using System;
using System.Linq;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SeniorAssistance.Database;
using SeniorAssistance.Modele;

namespace SeniorAssistance
{
	public partial class ContactPage : ContentPage
	{

		CrudDatabase database;

		ObservableCollection<ITable> Items1 { get; set; }

		public ContactPage()
		{
			InitializeComponent();
			database = new ConctactDatabase();

			Items1 = new ObservableCollection<ITable>();
			ItemList.ItemsSource = Items1;

			SaveItemButtom.Clicked += (sender, e) =>
			{
				if (string.IsNullOrWhiteSpace(Item.Text))
					return;

				database.SaveItem(new Contact
				{
					Firstname = Item.Text,
					Lastname = Item1.Text,
					Phone = Int32.Parse(Item2.Text),

				});

				RefreshList();
				Item.Text = string.Empty;
				Item1.Text = string.Empty;
				Item2.Text = string.Empty;
			};

			getData.Clicked += (sender, e) =>
			  {

				  RefreshList();


			  };
			ItemList.ItemTapped += async (sender, args) =>
			{
				// DisplayAlert("Delete Context Action", args.Item + " delete context action", "OK");
				var bird = args.Item;
				var answer = await DisplayAlert("Exit", "Do you wan't to delet this Contact", "Yes", "No");
				if (answer)
				{
					database.Connection.Delete(args.Item);

				}
				RefreshList();
				//var bird = args.Item as Bird;
				//if (bird == null) return;
				//Navigation.PushAsync(new DetailPage(bird));
				//list.SelectedItem = null;
			};


		}
		public void OnDelete(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
		}
		private void RefreshList()
		{
			Items1.Clear();
			var items = (from i in database.GetItems<Contact>()

						 select i);

			foreach (var item in items)
			{
				Items1.Add(item);
				// 
			}


		}
	}
}

