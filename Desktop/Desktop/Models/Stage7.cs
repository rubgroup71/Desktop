using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desktop.Models
{
    public class Stage7
    {
        public string ID { get; set; }
        public string Description { get; set; }

        internal List<Stage7> Read8()
        {
            DBservices dbs = new DBservices();
            List<Stage7> lc = dbs.Read8("ConnectionStringName", "Stage7");
            return lc;
        }
    }
}