using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desktop.Models
{
    public class Stage1
    {
        public string ID { get; set; }
        public string Description { get; set; }

        internal List<Stage1> Read()
        {
            DBservices dbs = new DBservices();
            List<Stage1> lc = dbs.read2("ConnectionStringName", "Stage1");
            return lc;
        }
    }
}
 
