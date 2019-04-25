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
        public string Type { get; set; }

        public Items(string itemserial,bool isstandatd,string email,string itemname,string type)
        {
            ItemSerial = itemserial;
            ItemName = itemname;
            IsStandard = isstandatd;          
            Email = email;
            Type = type;

        }
        public Items(string itemserial, string email)
        {
            ItemSerial = itemserial;
            ItemName = "part";
            IsStandard = false;
            Email = email;
            Type = "type";
            
        }
        public Items(string itemserial)
        {
            ItemSerial = itemserial;
            ItemName = "part";
            IsStandard = false;
            Type = "type";

        }
        public Items()
        {
        }

        public int InsertItem()
        {
            DBservices DBS = new DBservices();
            int numAffected = DBS.InsertItem(this);
            return numAffected;
        }

        public List<Items> FilterItems(string email)
        {
            DBservices DBS = new DBservices();
            List<Items> it = DBS.FilterItems(email);
            return it;
        }
        static public void delitem(string id)
        {
            DBservices DBS = new DBservices();
            DBS.del(id, "ItemsCustomer", "ItemID");
            
        }
    }
}