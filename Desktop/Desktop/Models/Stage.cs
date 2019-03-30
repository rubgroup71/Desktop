using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desktop.Models
{
    public class Stage
    {
        public string ID { get; set; }
        public string Description { get; set; }

        internal Dictionary<int, List<Stage>> Read()
        {

            DBservices dbs = new DBservices();
            return dbs.read1("ConnectionStringName");
            //return lc;
        }
    }
}