using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desktop.Models
{
    public class Stage8
    {
        public string ID { get; set; }
        public string Description { get; set; }
        internal List<Stage8> Read9()
        {
            DBservices dbs = new DBservices();
            List<Stage8> lc = dbs.Read9("ConnectionStringName", "Stage8");
            return lc;
        }
    }
}