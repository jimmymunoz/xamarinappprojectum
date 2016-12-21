using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace SeniorAssistance.Modele
{
    class ContactType : ITable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("[ContactType: ID={0}, Image={1}, Name={2}]", ID, Image, Name);
        }
    }
}
