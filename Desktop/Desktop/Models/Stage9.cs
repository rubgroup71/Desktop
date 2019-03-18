using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desktop.Models
{
    public class Stage9
    {
        public string ID { get; set; }
        public string Description { get; set; }
        internal List<Stage9> Read10()
        {
            DBservices dbs = new DBservices();
            List<Stage9> lc = dbs.Read10("ConnectionStringName", "Stage9");
            return lc;
        }
    }
}