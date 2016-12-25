using Java.Sql;
using SQLite;
using System;
using Xamarin.Forms;

namespace SeniorAssistance.Model
{
    class Alert : ITable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int Idmedicament { get; set; }

        public TimeSpan Hour { get; set; }

        public override string ToString()
        {
            return string.Format("[Alert: ID={0}, Idmedicament={1}, Hour={2}]", ID, Idmedicament, Hour);
        }
    }
}


