﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SeniorAssistance.Model;

namespace SeniorAssistance.Database
{
    class MedicamentHistoryDatabase : CrudDatabase
    {
        protected override void initDababase()
        {
            Connection.CreateTable<MedicamentHistory>();
        }
    }
}
