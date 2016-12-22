using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SeniorAssistance.Model;

namespace SeniorAssistance.Database
{
    class MedicamentDatabase : CrudDatabase
    {
        protected override void initDababase()
        {
            Connection.CreateTable<Medicament>();
        }
    }
}
