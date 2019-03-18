using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desktop.Models
{
    public class Stage4
    {
        public string ID { get; set; }
        public string Description { get; set; }

        internal List<Stage4> Read5()
        {
            DBservices dbs = new DBservices();
            List<Stage4> lc = dbs.read5("ConnectionStringName", "Stage4");
            return lc;
        }
    }
}