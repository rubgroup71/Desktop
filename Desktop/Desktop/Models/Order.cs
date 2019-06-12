using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Order
    {

        public string OrderDate { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");

        public string Status { get; set; } = "wait to confirm";
        public List<string> Part { get; set; }
        public List<string> Quantity { get; set; }
        //public int Addressid { get; set; }
        public int OrderId { get; set; }
        public Address Address { get; set; }
        public Items item { get; set; }


        public Order(List<string> _part, List<string> _qun,Address _address,Items _item,string _status)
        {
            Part = _part;
            Quantity = _qun;
            Address = _address;
            item = _item;
            Status = _status;
        }

        public Order()
        {
            Address = new Address();
            Part = new List<string>();
            Quantity = new List<string>();
            item = new Items();
        }

        public int insertO(List<string> parts, List<string> quantity)
        {
            DBservices DBS = new DBservices();
            int numAffected = DBS.insertO(this, parts, quantity);
            return numAffected;
        }
        public List<Order> GetOrders()
        {
            DBservices DBS = new DBservices();
            List<Order> orders= DBS.GetOrders();
            return orders;
        }
        public List<Order> FilterOrders(string e)
        {
            DBservices DBS = new DBservices();
            List<Order> orders = DBS.FilterOrders(e);
            return orders;
        }
        public static void Update(int id,string status)
        {
            DBservices DBS = new DBservices();
            DBS.UpdateS(id,status);
        }
    }
}