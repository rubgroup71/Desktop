using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Categories
    {
        public string Type { get; set; }
        public string Stages { get; set; }


        public Categories(string type,string stages)
        {
            Type = type;
            Stages = stages;
        }
        public Categories()
        {

        }

        public List<Categories> gettype()
        {
            DBservices DBS = new DBservices();
            List<Categories> h = DBS.gettype();
            return h;

        }


    }

}