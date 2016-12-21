using System;
using System.Collections.Generic;
using System.Text;
using SeniorAssistance.Modele;

namespace SeniorAssistance.Database
{
   public  class ContactTypeDatabase : CrudDatabase
    {
        protected override void initDababase()
        {
            Connection.CreateTable<ContactType>();
        }

    }
}
