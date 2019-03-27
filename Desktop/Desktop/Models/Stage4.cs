using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Stage4
    {
        public string ID { get; set; }
        public string Description { get; set; }




        public List<Stage4> Read5()
        {
            DBservices DBS = new DBservices();
            List<Stage4> h = DBS.read5("ConnectionStringName", "Stage4");
            return h;

        }
    }
}