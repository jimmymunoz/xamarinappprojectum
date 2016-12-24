using SeniorAssistance.Database;
using SeniorAssistance.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SeniorAssistance
{
	public partial class MedicamentsFormPage : ContentPage
	{
        CrudDatabase database;
        ObservableCollection<ITable> Items1 { get; set; }

        public MedicamentsFormPage()
        {
            InitializeComponent();

            database = new MedicamentDatabase();
            Items1 = new ObservableCollection<ITable>();
            // Liste des alert
            //ItemList.ItemsSource = Items1;

            
            BtnSave.Clicked += async (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(Name.Text) || string.IsNullOrWhiteSpace(Enabled.Text))
                    return;
                Medicament item = new Medicament
                {
                    Name = Name.Text,
                    //StartDate = StartDate.BindingContext
                    StartDate = ((DateTime)StartDate.Date),
                    Enabled = Enabled.Text,

                };
                if (!string.IsNullOrWhiteSpace(ID.Text))
                    item.ID = Int32.Parse(ID.Text);

                database.SaveItem(item);
                var answer = await DisplayAlert("Exit", "Want to add alert for this drug ", "Yes", "No");
                if (answer)
                {
                    var secondPage = new AlertFormPage();
                    secondPage.BindingContext = item;
                    await Navigation.PushAsync(secondPage);                    
                }
                else
                await Navigation.PushAsync(new MedicamentsPage());
            };
            
            BtnCancel.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new MedicamentsPage());
            };
            // Pour le delete 
            BtnDelete.Clicked += async (sender, e) =>
            {
                /*
                    * Normalement :c'est comme ça,malheureusement la methode getitem cast le type de l'item 
                   Contact contactToDelete= database.GetItem<Contact>(Int32.Parse(ID.Text));
                   database.DeleteItem(item);*/

                var answer = await DisplayAlert("Exit", "Do you wan't to delet ", "Yes", "No");
                if (answer)
                {
                    Medicament item = new Medicament
                    {
                        Name = Name.Text,                        
                        StartDate = ((DateTime)StartDate.Date),
                        Enabled = Enabled.Text,
                    };
                    item.ID = Int32.Parse(ID.Text);
                    database.Connection.Delete(item);

                    await Navigation.PushAsync(new MedicamentsPage());
                }
            };
        }

    }
}

