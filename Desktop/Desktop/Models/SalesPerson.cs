using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication2.Models
{
    public class SalesPerson
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Area { get; set; }
        public string Email { get; set; }
        public int ISAdmin { get; set; }


        public SalesPerson(string _username,string _password, string _firstname, string _lastname, int _phonenumber, string _area, string _email)
        {
            UserName = _username;
            Password = _password;
            FirstName = _firstname;
            LastName = _lastname;
            PhoneNumber = _phonenumber;
            Area = _area;
            Email = _email;
            ISAdmin = 0;
                }

        public SalesPerson()
        {

        }

        public int insertS()
        {
            DBservices DBS = new DBservices();
            int numAffected = DBS.insertS(this);
            return numAffected;
        }
        public SalesPerson Login( string username,string password)
        {
            DBservices DBS = new DBservices();
            return DBS.Login("ConnectionStringName", "SalesPerson",username,password);
        }

        internal void delete(string UserName)
        {
            DBservices DBS = new DBservices();
            DBS.del(UserName, "SalesPerson", "UserName");
        }

        public SalesPerson Test(string username)
        {
            DBservices DBS = new DBservices();
            return DBS.Test("ConnectionStringName", "SalesPerson", username);
        }

        public List<SalesPerson> Show()
        {
            DBservices DBS = new DBservices();
            List<SalesPerson> S = DBS.Show("ConnectionStringName", "SalesPerson");
            return S;
        }
        public void edit()
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.edit(this);


        }
    }
}