using Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Desktop.Controllers
{
    public class Stage7Controller : ApiController
    {
        // GET: api/Stage7
        public IEnumerable<Stage7> Get()
        {
            Stage7 s = new Stage7();
            List<Stage7> st = s.Read8();
            return st;

        }

        // GET: api/Stage7/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stage7
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stage7/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stage7/5
        public void Delete(int id)
        {
        }
    }
}
