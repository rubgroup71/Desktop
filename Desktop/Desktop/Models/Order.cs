using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Order
    {

        public string OrderDate { get; set; } = DateTime.Now.Date.ToShortDateString();
        public string Email { get; set; }
        public string Status { get; set; } = "Confirm";
        public List<string> Part { get; set; }
        public List<string> Quantity { get; set; }
        //public int Addressid { get; set; }
        public int OrderId { get; set; }
        public Address Address { get; set; }

        public Order(string _email, List<string> _part, List<string> _qun)
        {

            Email = _email;
            Part = _part;
            Quantity = _qun;
            Address = new Address();
        }

        public Order()
        {
            Address = new Address();
            Part = new List<string>();
            Quantity = new List<string>();
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
    }
}