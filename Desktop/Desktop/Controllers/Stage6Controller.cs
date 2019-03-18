using Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Desktop.Controllers
{
    public class Stage6Controller : ApiController
    {
        // GET: api/Stage6
        public IEnumerable<Stage6> Get()
        {
            Stage6 s = new Stage6();
            List<Stage6> st = s.Read7();
            return st;

        }

        // GET: api/Stage6/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stage6
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stage6/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stage6/5
        public void Delete(int id)
        {
        }
    }
}
