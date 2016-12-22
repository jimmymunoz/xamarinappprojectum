using SQLite;
using System;

namespace SeniorAssistance.Model
{
    class MedicamentHistory : ITable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int  IdAlert { get; set; }

        public string Message { get; set; }

        public DateTime SendDate { get; set; }

        public Boolean Taken { get; set; }

        public DateTime ExpireDate { get; set; }

        public Boolean Notified { get; set; }

        public override string ToString()
        {
            return string.Format("[MedacamentHistory: ID={0}, IdAlert={1}, Message={2},SendDate={3},Taken={4},ExpireDate={5},Notified={6}]", ID, IdAlert, Message, SendDate,Taken,ExpireDate, Notified);
        }
    }
}
