using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desktop.Models
{
    public class Stage5
    {
        public string ID { get; set; }
        public string Description { get; set; }

        internal List<Stage5> Read6()
        {
            DBservices dbs = new DBservices();
            List<Stage5> lc = dbs.read6("ConnectionStringName", "Stage5");
            return lc;
        }
    }
}