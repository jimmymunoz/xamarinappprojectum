using SQLite;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SeniorAssistance.Model
{
    class Medicament : ITable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }      

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string Enabled { get; set; }        

        public override string ToString()
        {
            //return string.Format("[Medicament: ID={0} Name={2}],StartDate={3},Enabled={4},AlertsMedicament={4}", ID, /*IdUser,*/ Name, StartDate, Enabled, AlertsMedicament);
            return string.Format("[Medicament: ID={0} Name={1},StartDate={2},Enabled={3}", ID,Name, StartDate, Enabled);
        }
    }    
}
