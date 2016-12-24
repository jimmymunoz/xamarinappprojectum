using Java.Sql;
using SeniorAssistance.Database;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SeniorAssistance.Database;
using SeniorAssistance.Model;
using Xamarin.Forms;

namespace SeniorAssistance
{
    public partial class AlertFormPage : ContentPage
    {
        CrudDatabase database;

        ObservableCollection<ITable> ListContacts { get; set; }

        public AlertFormPage()
        {
            database = new ConctactDatabase();
            InitializeComponent();

            //Items = new ObservableCollection<ITable>();

            //ItemList.ItemsSource = Items;

            Save.Clicked += (sender, e) =>
            {

                Alert item = new Alert
                {
                    Idmedicament = int.Parse(ID.Text),
                    Hour = Hour.Date,
                };
                if (!string.IsNullOrWhiteSpace(ID.Text))
                    item.ID = Int32.Parse(ID.Text);
            };
        }
        /*
        private void RefreshList()
        {
            Items.Clear();

            var items = (from i in database.GetItems<Alert>()
                         where i.Idmedicament = 
                         orderby i.Created descending
                         select i);

            foreach (var item in items)
                Items.Add(item);
        }
        */


    }
}
