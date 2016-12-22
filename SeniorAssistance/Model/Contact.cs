using SQLite;

namespace SeniorAssistance.Model
{
    class Contact : ITable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
       
        public int Phone { get; set; }

        public override string ToString()
        {
            return string.Format("[Contact: ID={0}, firstName={1}, lastName={2}],phone={2}]", ID, Firstname, Lastname, Phone);
        }
    }
}


