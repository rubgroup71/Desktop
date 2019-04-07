using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Items
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemSerial { get; set; }
        public bool IsStandard { get; set; }
        public string Email { get; set; }

        public Items(string itemserial,bool isstandatd,string email)
        {
            ItemSerial = itemserial;
            ItemName = "part";
            IsStandard = isstandatd;          
            Email = email;

        }
        public Items(string itemserial, string email)
        {
            ItemSerial = itemserial;
            ItemName = "part";
            IsStandard = false;
            Email = email;
        }
        public int InsertItem()
        {
            DBservices DBS = new DBservices();
            int numAffected = DBS.InsertItem(this);
            return numAffected;
        }
        

    }
}