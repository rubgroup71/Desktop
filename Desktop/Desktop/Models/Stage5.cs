using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Stage5
    {
        public string ID { get; set; }
        public string Description { get; set; }




        public List<Stage5> Read6()
        {
            DBservices DBS = new DBservices();
            List<Stage5> h = DBS.read6("ConnectionStringName", "Stage5");
            return h;

        }
    }
}