using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desktop.Models
{
    public class Stage10
    {
        public string ID { get; set; }
        public string Description { get; set; }

        internal List<Stage10> Read11()
        {
            DBservices dbs = new DBservices();
            List<Stage10> lc = dbs.Read11("ConnectionStringName", "Stage10");
            return lc;
        }
    }
}