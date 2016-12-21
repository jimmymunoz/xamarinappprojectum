using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SeniorAssistance.Modele;

namespace SeniorAssistance.Database
{
  public class ConctactDatabase : CrudDatabase
    {
        protected override void initDababase()
        {
            Connection.CreateTable<Contact>();
        }  
    }
}
