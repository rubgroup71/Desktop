using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Stage3
    {
        public string ID { get; set; }
        public string Description { get; set; }




        public List<Stage3> Read4()
        {
            DBservices DBS = new DBservices();
            List<Stage3> h = DBS.read4("ConnectionStringName", "Stage3");
            return h;

        }
    }
}