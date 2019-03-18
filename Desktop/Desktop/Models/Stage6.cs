using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desktop.Models
{
    public class Stage6
    {
        public string ID { get; set; }
        public string Description { get; set; }

        internal List<Stage6> Read7()
        {
            DBservices dbs = new DBservices();
            List<Stage6> lc = dbs.read7("ConnectionStringName", "Stage6");
            return lc;
        }
    }
}