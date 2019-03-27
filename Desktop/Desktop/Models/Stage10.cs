using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Stage10
    {
        public string ID { get; set; }
        public string Description { get; set; }




        public List<Stage10> Read11()
        {
            DBservices DBS = new DBservices();
            List<Stage10> h = DBS.Read11("ConnectionStringName", "Stage10");
            return h;

        }
    }
}