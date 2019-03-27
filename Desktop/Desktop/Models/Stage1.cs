using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Stage1
    {
        public string ID { get; set; }
        public string Description { get; set; }




        public List<Stage1> Read()
        {
            DBservices DBS = new DBservices();
            List<Stage1> h = DBS.read2("ConnectionStringName", "Stage1");
            return h;

        }
    }
}