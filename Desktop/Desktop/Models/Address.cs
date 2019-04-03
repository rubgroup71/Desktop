﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Address
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string City {get; set;}
        public string Email { get; set; }




        public Address(string _firstname, string _lastname, string _phonenumber, string _companyname, string _adress, string _city, string _email)
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
            List<Address> C = DBS.ShowA("ConnectionStringName", "Address");
            return C;
        }

    }
}