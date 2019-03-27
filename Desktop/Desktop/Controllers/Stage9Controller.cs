using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace Desktop.Controllers
{
    public class Stage9Controller : ApiController
    {
        // GET: api/Stage9
        public IEnumerable<Stage9> Get()
        {
            Stage9 s = new Stage9();
            List<Stage9> st = s.Read10();
            return st;
        }

        // GET: api/Stage9/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stage9
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stage9/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stage9/5
        public void Delete(int id)
        {
        }
    }
}
