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

        public Items(string itemname,string itemserial,bool isstandatd,int itemid,string email)
        {
            ItemSerial = itemserial;
            ItemName = itemname;
            IsStandard = isstandatd;
            ItemID = itemid;
            Email = email;

        }
        public int InsertItem(int quantity)
        {
            DBservices DBS = new DBservices();
            int numAffected = DBS.InsertItem(this,quantity);
            return numAffected;
        }
    }
}