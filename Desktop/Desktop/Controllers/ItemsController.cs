using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace Desktop.Controllers
{
    public class ItemsController : ApiController
    {
        // GET: api/Items
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Items/5
        public List<Items> Get(string email)
        {
            Items i = new Items();
            List<Items> item = i.FilterItems(email);
            return item;
        }

        // POST: api/Items
        public void Post([FromBody]Items item)
        {
            item.InsertItem();
        }

        // PUT: api/Items/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Items/5
        public void Delete(int id)
        {
        }
    }
}
