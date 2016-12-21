using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SeniorAssistance.Modele
{
    class User : ITable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
        
        public string Phone { get; set; }

        public string Adresse { get; set; }
    
        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("[User: ID={0}, Firstname={1}, Lastname={2},Phone={3},Age={4},Adresse{5}]", ID, Firstname, Lastname, Phone,Age,Adresse);
        }
    }
}


