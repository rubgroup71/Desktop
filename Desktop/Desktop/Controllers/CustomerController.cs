using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomerController : ApiController
    {
        //GET: api/Customer
        public IEnumerable<Customer> Get()
        {
           Customer C = new Customer();
            List<Customer> CUS = C.ShowEmail();
            return CUS;
        }

        // GET: api/Customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        public void Post([FromBody]string email)
        {
            Customer C = new Customer(email);
            C.insertC();
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
