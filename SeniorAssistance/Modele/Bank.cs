using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeniorAssistance.Modele
{
    class Bank :ITable
    { 
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int IdContact { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Url { get; set; }

        public override string ToString()
        {
            return string.Format("[Bank: ID={0},IdContact={1},Name={2}],Image={3},Url={4}]", ID, IdContact, Name, Image,Url);
        }
    }
}

