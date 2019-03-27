using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Stage7
    {
        public string ID { get; set; }
        public string Description { get; set; }




        public List<Stage7> Read8()
        {
            DBservices DBS = new DBservices();
            List<Stage7> h = DBS.Read8("ConnectionStringName", "Stage7");
            return h;

        }
    }
}