using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

        public Order(DateTime _orderdate, string _email,int _ordernum)
        {
            OrderDate = _orderdate;
            Email = _email;
            Status ="Confirm";
            OrderNumber = _ordernum;

        }

        public Order()
        {
        }

        public int insertO()
        {
            DBservices DBS = new DBservices();
            int numAffected = DBS.insertO(this);
            return numAffected;
        }

        public List<Order> FilterOrder(int orderid)
        {
            DBservices dbs = new DBservices();
            List<Order> h = dbs.FilterOrder("ConnectionStringName", "Orders", orderid);
            return h;
        }
    }
}