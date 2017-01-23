using System.Linq;
using System.Collections.ObjectModel;
using SeniorAssistance.Database;
using SeniorAssistance.Model;
using Xamarin.Forms;
using System;
using System.Collections.Generic;

namespace SeniorAssistance
{
    public partial class AlertFormPage : ContentPage
    {
        AlertDatabase database;
		ObservableCollection<Alert> ListAlerts { get; set; }
        public Medicament medicament;
        Dictionary<string, int> Frequence;
        int freq;


        public AlertFormPage(Medicament medicament)
        {
			InitializeComponent();
            this.medicament = medicament;
            database = new AlertDatabase();
            ListAlerts = new ObservableCollection<Alert>();
            AlertsView.ItemsSource = ListAlerts;

            Frequence = new Dictionary<string, int>
            {
                { "Every day", 1},
                { "Every 2 days", 2},
                { "Every 3 days", 3},
                { "Every 4 days", 4},
                { "Every 5 days", 5},
                { "Every 6 days", 6},
                { "Every 7 days", 7},
                { "Every 8 days", 8},
                { "Every 9 days", 9},
                { "Every 10 days", 10},
                { "Every 11 days", 11},
                { "Every 12 days", 12},
                { "Every 13 days", 13},
                { "Every 14 days", 14},
                { "Every 15 days", 15},
                { "Every 16 days", 16},
                { "Every 17 days", 17},
                { "Every 18 days", 18},
                { "Every 19 days", 19},
                { "Every 20 days", 20},
                { "Every 21 days", 21},
                { "Every 22 days", 22},
                { "Every 23 days", 23},
                { "Every 24 days", 24},
                { "Every 25 days", 25},
                { "Every 26 days", 26},
                { "Every 27 days", 27},
                { "Every 28 days", 28},
                { "Every 29 days", 29},
                { "Every 30 days", 30},
            };
            foreach (string frequenceitem in Frequence.Keys)
            {
                picker.Items.Add(frequenceitem);
            }

            /*  var tapImageMedicaments = new TapGestureRecognizer();
              tapImageMedicaments.Tapped += clickImageDelete;
              btnAlertDelete.GestureRecognizers.Add(tapImageMedicaments);*/
            
            Save.Clicked += (sender, e) =>
            {
               
                picker.SelectedIndexChanged += (senderp, args) =>
                {
                    freq = picker.SelectedIndex;
                };

                //Debug.WriteLine("Action: " + action);
                /*
                if (!string.IsNullOrWhiteSpace(Hour.Text))
                    return;
                */
                //item.ID = Int32.Parse(Idmedicament.Text);

                Alert item = new Alert
                {
                    Idmedicament = medicament.ID,
                    Hour = Hour.Time.ToString(),
                    Freq = freq,
                };
                database.SaveItem(item);
                RefreshList(medicament);
            };
            RefreshList(medicament);



        }

        void OnTapGestureRecognizerTappedDelete(object sender, EventArgs arg)
        {
            AlertsView.ItemTapped += (sende, args) =>
             {
                 var bird = args.Item;
                 database.Connection.Delete(bird);
                 RefreshList(medicament);
             };

            RefreshList(medicament);

        }
        void clickImageDelete(object sender, EventArgs e)
        {
         
               
        }

        private void RefreshList(Medicament medicament)
        {
            ListAlerts.Clear();
            int id = medicament.ID;

            var items = (from i in database.GetItems<Alert>()
                 where i.Idmedicament == id
                 select i);

            foreach (var item in items)
                ListAlerts.Add(item);
        }
    }
}
