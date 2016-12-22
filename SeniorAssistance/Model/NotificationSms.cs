using SQLite;

namespace SeniorAssistance.Model
{ 
    class NotificationSms : ITable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Message { get; set; }

        public int IdContact { get; set; }

        public bool Send { get; set; }

        public int IdMedicamentHistory { get; set; }

        public override string ToString()
        {
            return string.Format("[NotificationSms: ID={0}, Message={1}, IdContact={2}],Send={2},IdMedicamentHistory={3}]", ID, Message, IdContact, Send, IdMedicamentHistory);
        }
    }
}
