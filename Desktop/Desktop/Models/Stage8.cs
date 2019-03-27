using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Stage8
    {
        public string ID { get; set; }
        public string Description { get; set; }




        public List<Stage8> Read9()
        {
            DBservices DBS = new DBservices();
            List<Stage8> h = DBS.Read9("ConnectionStringName", "Stage8");
            return h;

        }
    }
}