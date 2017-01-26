using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SeniorAssistance.Database;
using SeniorAssistance.Model;
using Xamarin.Forms;
using SeniorAssistance;

namespace SeniorAssistance
{
	public partial class MedicamentsPage : ContentPage
	{
        MedicamentDatabase database;

        ObservableCollection<Medicament> ListMedicaments { get; set; }

        public MedicamentsPage()
		{
            database = new MedicamentDatabase();
            InitializeComponent();            
            ListMedicaments = new ObservableCollection<Medicament>();
            MedicamentsView.ItemsSource = ListMedicaments;
            
            btnAdd.Clicked += (sender, e) =>
			{
				Navigation.PushAsync(new MedicamentsFormPage());
			};
            MedicamentsView.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    var medicament = e.SelectedItem as Medicament;
                    var secondPage = new MedicamentsFormPage();
                    secondPage.BindingContext = medicament;
                    Navigation.PushAsync(secondPage);
                }
            };
            RefreshList();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            System.Diagnostics.Debug.WriteLine("*****Here*****");
            
        }

        private void RefreshList()
        {
            ListMedicaments.Clear();
            var items = (from i in database.GetItems<Medicament>()
                         select i);

            foreach (var item in items)
            {
                ListMedicaments.Add(item);
            }
        }
    }
}
