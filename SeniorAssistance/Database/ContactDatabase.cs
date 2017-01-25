using System;
using System.Collections.Generic;
using System.Text;
using SeniorAssistance.Model;

namespace SeniorAssistance.Database
{
  public class MedicamentHistoryDatabase : CrudDatabase
    {
        protected override void initDababase()
        {
            Connection.CreateTable<MedicamentHistory>();
        }  
    }
}
