using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace Desktop.Models
{
    public class Stage
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        internal Dictionary<int, List<Stage>> Read(string type, string stages)
        {

            DBservices dbs = new DBservices();
            return dbs.read1(type,stages);
            //return lc;
        }
    }
}