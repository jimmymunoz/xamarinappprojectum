using SeniorAssistance.Database;
using SeniorAssistance.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace SeniorAssistance
{
    public partial class MedicamentsFormPage : ContentPage
    {
		MedicamentDatabase database;
		Medicament medicament;
		AlertDatabase databasealert;
		ObservableCollection <Medicament> Items1 { get; set; }

        public MedicamentsFormPage()
        {
            InitializeComponent();
            databasealert = new AlertDatabase();
            database = new MedicamentDatabase();
            Items1 = new ObservableCollection<Medicament>();
            
            BtnSave.Clicked += async (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(Name.Text))
					return;
                
				medicament = new Medicament
                {
                    Name = Name.Text,                   
                    StartDate = StartDate.Date,
                    Enabled = Enabled.IsToggled,

                };
                if (!string.IsNullOrWhiteSpace(ID.Text))
                {
                    medicament.ID = Int32.Parse(ID.Text);
                }
                database.SaveItem(medicament);

                var answer = await DisplayAlert("Exit", "Want to add alert for this Medicament : " + medicament.Name, "Yes", "No");
                if (answer)
                {
                    await Navigation.PushAsync(new AlertFormPage(medicament));

                }
                else
                    await Navigation.PushAsync(new MedicamentsPage());
            };

            BtnCancel.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new MedicamentsPage());
            };
            
			BtnDelete.Clicked += async (sender, e) =>
            {
                /*
                    * Normalement :c'est comme ça,malheureusement la methode getitem cast le type de l'item 
                   Contact contactToDelete= database.GetItem<Contact>(Int32.Parse(ID.Text));
                   database.DeleteItem(item);*/
                   
                var answer = await DisplayAlert("Exit", "Do you want to delete", "Yes", "No");
                if (answer)
                {
                    Medicament item = new Medicament
                    {
                        Name = Name.Text,
                        StartDate = ((DateTime)StartDate.Date),
                        // Enabled = Int32.Parse(Enabled.Text)
                    };
                    item.ID = Int32.Parse(ID.Text);
                    database.Connection.Delete(item);

                    await Navigation.PushAsync(new MedicamentsPage());
                }
            };

            BtnAlert.Clicked += async (sender, e) =>
            {

                medicament = new Medicament
                {
                    Name = Name.Text,
                    //StartDate = StartDate.BindingContext
                    StartDate = StartDate.Date,
                    Enabled = Enabled.IsToggled,

                };
                if (!string.IsNullOrWhiteSpace(ID.Text))
                {
                    medicament.ID = Int32.Parse(ID.Text);
                }
                database.SaveItem(medicament);
                /*
                int items = (from i in databasealert.Connection.Table<Alert>()
                            where i.Idmedicament == item.ID                         
                             select i).Count();

                if (items > 0)
                {*/
                await Navigation.PushAsync(new AlertFormPage(medicament));
            };
        }
    }
}

