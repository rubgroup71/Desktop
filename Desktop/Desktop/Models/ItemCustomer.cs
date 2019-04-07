using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ItemCustomer
    {
        public int ItemID { get; set; }       
        public string Email { get; set; }


        public List<ItemCustomer> FilterItemCustomer(string email)
        {
            DBservices dbs = new DBservices();
            List<ItemCustomer> h = dbs.FilterItemCustomer("ConnectionStringName", "ItemsCustomer", email);
            return h;
        }

    }
}