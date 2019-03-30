using Desktop.Models;
//using Desktop.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Desktop.Controllers
{
    public class AllItemController : ApiController
    {
        // GET: api/AllItem
        public Dictionary<int, List<Stage>> Get()
        {
            Stage s = new Stage();
            return s.Read();

        }

        // GET: api/AllItem/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AllItem
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AllItem/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AllItem/5
        public void Delete(int id)
        {
        }
    }
}
