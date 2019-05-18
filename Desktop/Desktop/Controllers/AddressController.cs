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
        [HttpGet]
        [Route("api/Address/5")]
        public IEnumerable<Address>GetAddress(string email)
        {
            Address AD = new Address();
            List<Address> a = AD.FilterAddress(email);
            return a;
        }

        // GET: api/Address/5
        public Address Get(string address)
        {
            Address C = new Address();
            return C.getcustomer(address);
        }
    
    

        // POST: api/Address
        public void Post([FromBody]Address A)
        {
            A.insertA();

        }
        
        // PUT: api/Address/5
        public void Put(string id,[FromBody]Address A)
        {
            A.updateA(id);
        }

        // DELETE: api/Address/5
        public void Delete(string id)
        {
            Address.deladdress(id);
        }
        public void DeleteCUST(int ID)
        {
            Address a = new Address();
            a.delete(ID);
        }
    }
}
