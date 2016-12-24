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
        CrudDatabase database, database1;
        ObservableCollection<ITable> Items1 { get; set; }

        public MedicamentsFormPage()
        {
            InitializeComponent();
            database = new MedicamentDatabase();
            database1 = new AlertDatabase();

            Items1 = new ObservableCollection<ITable>();
            // Liste des alert
            ItemList.ItemsSource = Items1;

            
            BtnSave.Clicked += (sender, e) =>
            {
                /*
                Alert alert = new Alert
                {

                };

                if (string.IsNullOrWhiteSpace(Name.Text) || string.IsNullOrWhiteSpace(StartDate.Text) || string.IsNullOrWhiteSpace(Enabled.Text))

                    return;
                Medicament item = new Medicament
                {
                    Name = Name.Text,
                    StartDate = StartDate.Text,
                    Enabled = Convert.ToBoolean(Enabled.Text),
                    AlertsMedicament = new List<Alert>Items1;
                };
                if (!string.IsNullOrWhiteSpace(ID.Text))
                    item.ID = Int32.Parse(ID.Text);

                database.SaveItem(item);
                Navigation.PopAsync();*/
            };
            
            BtnCancel.Clicked += (sender, e) =>
            {
                Navigation.PopAsync();
            };
        }

    }
}

