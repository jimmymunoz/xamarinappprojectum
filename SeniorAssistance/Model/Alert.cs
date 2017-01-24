using SQLite;

namespace SeniorAssistance.Model
{
    class Alert : ITable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int Idmedicament { get; set; }

        public string Hour { get; set; }

        public int Freq { get; set; }

        public override string ToString()
        {
            return string.Format("[Alert: ID={0}, Idmedicament={1}, Hour={2}, Freq{2}]", ID, Idmedicament, Hour,Freq);
        }
    }
}


