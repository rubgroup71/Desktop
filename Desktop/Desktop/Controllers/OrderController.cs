using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace Desktop.Controllers
{
    public class OrderController : ApiController
    {
        // GET: api/Order
        public IEnumerable<Order> Get()
        {
            Order O = new Order();
            List<Order> orders = O.GetOrders();
            return orders;
        }


        // GET: api/Order/5
        public List<Order> Get(string email)
        {
            Order O = new Order();
            List<Order> orders = O.FilterOrders(email);
            return orders;
        }

        // POST: api/Order
        public void Post([FromBody]Order O, int address)
        {
            O.insertO(O.Part, O.Quantity, address);
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
        }
    }
}
