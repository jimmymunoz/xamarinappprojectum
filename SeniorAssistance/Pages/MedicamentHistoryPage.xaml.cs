using SeniorAssistance.Database;
using SeniorAssistance.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SeniorAssistance.Pages
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
            //ContactsViewAppel.ItemsSource = ListMedicamentHistory;

            RefreshList();
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
    }
}
