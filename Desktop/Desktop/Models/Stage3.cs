﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desktop.Models
{
    public class Stage3
    {
        public string ID { get; set; }
        public string Description { get; set; }

        internal List<Stage3> Read4()
        {
            DBservices dbs = new DBservices();
            List<Stage3> lc = dbs.read4("ConnectionStringName", "Stage3");
            return lc;
        }
    }
}