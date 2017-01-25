using SQLite;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SeniorAssistance.Model
{
    public class Medicament : ITable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }      

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public bool Enabled { get; set; }   

		public string EnabledText => string.Format("{0}{1}", (Enabled) ? "Enabled" : "Disabled", "");

		public string EnabledColor => string.Format("{0}", (Enabled) ? "#119b31" : "#f20909");

        public override string ToString()
        {
            //return string.Format("[Medicament: ID={0} Name={2}],StartDate={3},Enabled={4},AlertsMedicament={4}", ID, /*IdUser,*/ Name, StartDate, Enabled, AlertsMedicament);
            return string.Format("[Medicament: ID={0} Name={1},StartDate={2},Enabled={3}", ID,Name, StartDate, Enabled);
        }
    }    
}
