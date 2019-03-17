using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemNumber { get; set; }
        public Boolean Standard { get; set; }
        public string ItemName { get; set; }
    }
}