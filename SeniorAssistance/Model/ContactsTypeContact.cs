using SQLite;

namespace SeniorAssistance.Model
{
    class ContactsTypeContact : ITable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Image { get; set; }

        public string TypeContact { get; set; }
        
        public string Phone { get; set; }

        public override string ToString()
        {
            return string.Format("[Contact: ID={0}, firstName={1}, lastName={2},Image {3},TypeContact {4},phone={5}]", ID, Firstname, Lastname,Image, TypeContact, Phone);
        }
    }
}


