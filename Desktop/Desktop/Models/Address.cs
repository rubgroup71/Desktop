using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Address
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string City {get; set;}
        public string Email { get; set; }




        public Address(string _firstname, string _lastname, string _phonenumber, string _companyname, string _adress, string _city, string _email,int _id)
        {
            //UserName = _username;
            //Password = _password;
            FirstName = _firstname;
            LastName = _lastname;
            PhoneNumber = _phonenumber;
            CompanyName = _companyname;
            Adress = _adress;
            City = _city;
            Email = _email;
            ID = _id;

        }
        
        public Address()
        {

        }

        public int insertA()
        {
            DBservices DBS = new DBservices();
            int numAffected = DBS.insertA(this);
            return numAffected;
        }
        public List<Address> Show()
        {
            DBservices DBS = new DBservices();
            List<Address> C = DBS.ShowA("ConnectionStringName", "Addresses");
            return C;
        }
        public Address getcustomer(string address)
        {
            DBservices dbs = new DBservices();
            Address p = dbs.getcustomer("ConnectionStringName", "Addresses",address);
            return p;
        }

        public List<Address> FilterAddress(string email) { 
        
            DBservices dbs = new DBservices();
            List<Address> h = dbs.FilterAddress("ConnectionStringName", "AddressCutomer", email);
            return h;
        }
        static public void deladdress(string id)
        {
            DBservices DBS = new DBservices();
            DBS.del(id, "AddressCustomer", "AddressID");
        }
    
    }
}