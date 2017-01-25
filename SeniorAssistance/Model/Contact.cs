using SQLite;

namespace SeniorAssistance.Model
{
    class Contact: ITable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
        
        public string FullName => string.Format("{0} {1}", Firstname, Lastname);

        public string TypeContact { get; set; }

        public string Phone { get; set; }
        public bool Urgence { get; set; }

        public override string ToString()
        {
            return string.Format("[Contact: ID={0}, firstName={1}, lastName={2},TypeContact {3},phone={4},Urgence={5}]", ID, Firstname, Lastname, TypeContact, Phone,Urgence);
        }
    }
}


