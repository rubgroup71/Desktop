using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desktop.Models
{
    public class Stage2
    {
        public string ID { get; set; }
        public string Description { get; set; }

        internal List<Stage2> Read3()
        {
            DBservices dbs = new DBservices();
            List<Stage2> lc = dbs.read3("ConnectionStringName","Stage2");
            return lc;
        }
    }
}