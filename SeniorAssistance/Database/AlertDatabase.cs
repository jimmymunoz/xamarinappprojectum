﻿using System;
using System.Collections.Generic;
using System.Text;
using SeniorAssistance.Model;

namespace SeniorAssistance.Database
{
    public class AlertDatabase: CrudDatabase
    {

        protected override void initDababase()
        {
            Connection.CreateTable<Alert>();
        }

    }
}
