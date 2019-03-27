using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Stage2
    {
        public string ID { get; set; }
        public string Description { get; set; }




        public List<Stage2> Read3()
        {
            DBservices DBS = new DBservices();
            List<Stage2> h = DBS.read3("ConnectionStringName", "Stage2");
            return h;

        }
    }
}