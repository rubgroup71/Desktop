using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Stage9
    {
        public string ID { get; set; }
        public string Description { get; set; }




        public List<Stage9> Read10()
        {
            DBservices DBS = new DBservices();
            List<Stage9> h = DBS.Read10("ConnectionStringName", "Stage9");
            return h;

        }
    }
}