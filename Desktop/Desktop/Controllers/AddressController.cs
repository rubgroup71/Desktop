using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AddressController : ApiController
    {
        // GET: api/Address
        public IEnumerable<Address> Get()
        {
            Address C = new Address();
            List<Address> CUS = C.Show();
            return CUS;
        }
        public IEnumerable<Address> Get(int email)
        {
            Address AD = new Address();
            List<Address> a = AD.Filter(email);
            return a;
        }

        // GET: api/Address/5
        public Address Get(string email)
        {
            Address C = new Address();
            return C.getcustomer(email);
        }

        // POST: api/Address
        public void Post([FromBody]Address A)
        {
            A.insertA();

        }
        
        // PUT: api/Address/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Address/5
        public void Delete(int id)
        {
        }
    }
}
