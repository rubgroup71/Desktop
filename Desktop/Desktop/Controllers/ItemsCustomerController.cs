using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace Desktop.Controllers
{
    public class ItemsCustomerController : ApiController
    {
        // GET: api/ItemsCustomer
        public IEnumerable<ItemCustomer> Get(string email)
        {
            ItemCustomer ic = new ItemCustomer();
            List<ItemCustomer> a = ic.FilterItemCustomer(email);
            return a;
        }

        // GET: api/ItemsCustomer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ItemsCustomer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ItemsCustomer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ItemsCustomer/5
        public void Delete(int id)
        {
        }
    }
}
