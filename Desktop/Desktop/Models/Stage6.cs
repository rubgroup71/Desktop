using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Stage6
    {
        public string ID { get; set; }
        public string Description { get; set; }




        public List<Stage6> Read7()
        {
            DBservices DBS = new DBservices();
            List<Stage6> h = DBS.read7("ConnectionStringName", "Stage6");
            return h;

        }
    }
}