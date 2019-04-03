using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication2.Models
{
    public class Customer
    {
      
        public string Email { get; set; }



        public Customer(string _email)
        {
           
            Email = _email;
          
                }

        public Customer()
        {

        }

        public int insertC()
        {
            DBservices DBS = new DBservices();
            int numAffected = DBS.insertC(this);
            return numAffected;
        }

        //public SalesPerson Login( string username,string password)
        //{
        //    DBservices DBS = new DBservices();
        //    return DBS.Login("ConnectionStringName", "SalesPerson",username,password);
        //}

        public List<Customer> ShowEmail()
        {
            DBservices DBS = new DBservices();
            List<Customer> C = DBS.ShowEmail("ConnectionStringName", "Customer");
            return C;
        }
    }
}