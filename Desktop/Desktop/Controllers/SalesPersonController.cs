using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SalesPersonController : ApiController
    {
        // GET: api/SalesPerson
        public IEnumerable<SalesPerson> Get()
        {
            SalesPerson SA = new SalesPerson();
            List<SalesPerson> S = SA.Show();
            return S;
        }

        // GET: api/SalesPerson/5
        public SalesPerson Get(string username, string password)
        {
            SalesPerson S = new SalesPerson();
            return S.Login(username, password);
        }
        public SalesPerson Get(string username)
        {
            SalesPerson S = new SalesPerson();
            return S.Test(username);
        }

        // POST: api/SalesPerson
        public void Post([FromBody]SalesPerson S)
        {
            
            S.insertS();


     
        }

        // PUT: api/SalesPerson/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SalesPerson/5
        public void Delete(string UserName)
        {
            SalesPerson S = new SalesPerson();
            S.delete(UserName);

        }
    }
}
