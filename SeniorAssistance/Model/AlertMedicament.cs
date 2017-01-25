using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorAssistance.Model
{
    class AlertMedicament
    {
        public int IdAlert { get; set; }

        public int Idmedicament { get; set; }

        public string Hour { get; set; }

        public int Freq { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public bool Enabled { get; set; }

    }
}
