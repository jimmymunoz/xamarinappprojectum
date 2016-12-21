using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SeniorAssistance.Database;

namespace SeniorAssistance.Modele
{
    class Medicament : ITable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int IdUser { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public Boolean enabled { get; set; }

        public List<Alert> AlertsMedicament { get; set; }

        public override string ToString()
        {
            return string.Format("[Medicament: ID={0}, IdUser={1}, Name={2}],StartDate={3},enabled={4},AlertsMedicament={4}", ID, IdUser, Name, StartDate, enabled, AlertsMedicament);
        }
    }    
}
