using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication2.Models
{
    public class Customer
    {
        public string UID { get; set; }



        public Customer(string _uid)
        {
            UID = _uid;
          
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

        //public List<Customer> Show()
        //{
        //    DBservices DBS = new DBservices();
        //    List<Customer> C = DBS.ShowCustomer("ConnectionStringName", "Address");
        //    return C;
        //}
    }
}