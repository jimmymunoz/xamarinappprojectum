using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SeniorAssistance.Database;
using SeniorAssistance.Model;
using Xamarin.Forms;
using System;

namespace SeniorAssistance
{
    public partial class AlertFormPage : ContentPage
    {
        AlertDatabase database;

        ObservableCollection<Alert> ListAlerts { get; set; }

        
        public AlertFormPage(Medicament medicament)
        {

            InitializeComponent();
            database = new AlertDatabase();
            ListAlerts = new ObservableCollection<Alert>();

            AlertsView.ItemsSource = ListAlerts;

            Save.Clicked += (sender, e) =>
            {
                /*
                if (!string.IsNullOrWhiteSpace(Hour.Text))
                    return;
                */
                //item.ID = Int32.Parse(Idmedicament.Text);

                Alert item = new Alert
                {
                    Idmedicament = medicament.ID,
                    Hour = Hour.Time,
                };

                /*
                if (!string.IsNullOrWhiteSpace(Idmedicament.Text))
                    item.ID = Int32.Parse(Idmedicament.Text);
                */

                database.SaveItem(item);
            };
            // RefreshList();
        }
        /*
                private void RefreshList()
                {
                    ListAlerts.Clear();
                    int id = Int32.Parse(ID.Text);

                    var items = (from i in database.GetItems<Alert>()
                                 where i.Idmedicament == id
                                 select i);

                    foreach (var item in items)
                        ListAlerts.Add(item);
                }
                */


    }
}
