using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class IOC
    {
        public int OrderNum { get; set; }
        public int Quantity { get; set; }
        public string Email { get; set; }
        public int ItemID { get; set; }

        public IOC(int _quantity,string _email,int _ordernum,int _itemid)
        {
            Quantity = _quantity;
            Email = _email;
            OrderNum = _ordernum;
            ItemID = _itemid;
        }

        public IOC()
        {

        }
        //public int InsertIOC()
        //{
        //    DBservices DBS = new DBservices();
        //    int numAffected = DBS.InsertIOC(this);
        //    return numAffected;
        //}
    }
}