using SeniorAssistance.Database;
using SeniorAssistance.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SeniorAssistance
{
    public partial class MedicamentHistoryPage : ContentPage
    {
        
        MedicamentHistoryDatabase database;
        ObservableCollection<MedicamentHistory> ListMedicamentHistory { get; set; }
        
        public MedicamentHistoryPage()
        {
            InitializeComponent();
            database = new MedicamentHistoryDatabase();
            ListMedicamentHistory = new ObservableCollection<MedicamentHistory>();
            MedicamentsHistoryView.ItemsSource = ListMedicamentHistory;

            RefreshList();
            MedicamentsHistoryView.ItemSelected += async (sender, e) =>
            {
                await DisplayAlert("Selected", e.SelectedItem.ToString() + " was selected.", "OK");
            };
        }

        private void RefreshList()
        {
            ListMedicamentHistory.Clear();
            var items = (from i in database.GetItems<MedicamentHistory>()
                         select i);

            foreach (var item in items)
            {
                ListMedicamentHistory.Add(item);
            }
        }


        void switcher_Toggled(object sender, ToggledEventArgs e)
        {
            Debug.WriteLine("Switch is now {0}", e.Value);
            Debug.WriteLine("Switch is {0}", e.ToString());
            Debug.WriteLine("Switch is now {0}", e.GetHashCode());
            Debug.WriteLine("Switch GetType {0}", e.GetType());
            Debug.WriteLine("sender {0}", sender.GetHashCode());
            Debug.WriteLine("sender {0}", sender.GetType());
            //ListMedicamentHistory
            //database.Connection.SaveItem(medhistory);
            //RefreshList(medicament);
            //database.SaveItem
        }
    }
}
