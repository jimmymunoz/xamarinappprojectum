using System.Linq;
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
        public Medicament medicament;
        
        public AlertFormPage(Medicament medicament)
        {
			InitializeComponent();
            this.medicament = medicament;
            database = new AlertDatabase();
            ListAlerts = new ObservableCollection<Alert>();
            AlertsView.ItemsSource = ListAlerts;

          /*  var tapImageMedicaments = new TapGestureRecognizer();
            tapImageMedicaments.Tapped += clickImageDelete;
            btnAlertDelete.GestureRecognizers.Add(tapImageMedicaments);*/

            RefreshList(medicament);

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
					Hour = Hour.Time.ToString(),
               
                };                                              
                database.SaveItem(item);
				RefreshList(medicament);
            };
           
                
          
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
