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
        CrudDatabase database;

        ObservableCollection<ITable> ListMedicaments { get; set; }

        public MedicamentsPage()
		{
            database = new ConctactDatabase();
            InitializeComponent();            
            ListMedicaments = new ObservableCollection<ITable>();
            MedicamentsView.ItemsSource = ListMedicaments;
            RefreshList();

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
