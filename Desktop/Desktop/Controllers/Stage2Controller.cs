using Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Desktop.Controllers
{
    public class Stage2Controller : ApiController
    {
        // GET: api/Stage2
        public IEnumerable<Stage2> Get()
        {
            Stage2 s = new Stage2();
            List<Stage2> st = s.Read3();
            return st;
        }

        // GET: api/Stage2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stage2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stage2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stage2/5
        public void Delete(int id)
        {
        }
    }
}
