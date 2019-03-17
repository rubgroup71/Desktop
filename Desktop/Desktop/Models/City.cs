using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class City
    {
        public string Name { get; set; }




        public List<City> Read()
        {
            DBservices DBS = new DBservices();
            List<City> h = DBS.Read("ConnectionStringName", "City");
            return h;

        }
    }
}