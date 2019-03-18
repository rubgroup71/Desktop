using Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Desktop.Controllers
{
    public class Stage5Controller : ApiController
    {
        // GET: api/Stage5
        public IEnumerable<Stage5> Get()
        {
            Stage5 s = new Stage5();
            List<Stage5> st = s.Read6();
            return st;
        }

        // GET: api/Stage5/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stage5
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stage5/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stage5/5
        public void Delete(int id)
        {
        }
    }
}
