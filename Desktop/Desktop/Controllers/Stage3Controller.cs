using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace Desktop.Controllers
{
    public class Stage3Controller : ApiController
    {
        // GET: api/Stage3
        public IEnumerable<Stage3> Get()
        {
            Stage3 s = new Stage3();
            List<Stage3> st = s.Read4();
            return st;
        }

        // GET: api/Stage3/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stage3
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stage3/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stage3/5
        public void Delete(int id)
        {
        }
    }
}
