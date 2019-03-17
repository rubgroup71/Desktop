using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication2.Models
{
    public class Customer
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


        public Customer(string _username,string _password, string _firstname, string _lastname, int _phonenumber,string _companyname,string _address, string _city, string _country)
        {
            UserName = _username;
            Password = _password;
            FirstName = _firstname;
            LastName = _lastname;
            PhoneNumber = _phonenumber;
            CompanyName = _companyname;
            Address = _address;
            City =_city;
            Country =_country;
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

        //public List<SalesPerson> Show()
        //{
        //    DBservices DBS = new DBservices();
        //    List<SalesPerson> S = DBS.Show("ConnectionStringName", "SalesPerson");
        //    return S;
        //}
    }
}