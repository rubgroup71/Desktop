using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Order
    {
        
        public string OrderDate { get; set; }= DateTime.Now.Date.ToShortDateString();
        public string Email { get; set; }
        public string Status { get; set; } = "Confirm";
        public string [] Part { get; set; }
        public string[] Quantity { get; set; }

        public Order(string _email,string [] _part, string[] _qun)
        {

            //OrderDate = 
            Email = _email;
          
            
            Part = _part;
            Quantity = _qun;
        }

        public Order()
        {
        }

        public int insertO(string [] parts, string[] quantity)
        {
            DBservices DBS = new DBservices();
            int numAffected = DBS.insertO(this, parts, quantity);
            return numAffected;
        }

       
    }
}