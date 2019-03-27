using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace Desktop.Controllers
{
    public class Stage8Controller : ApiController
    {
        // GET: api/Stage8
        public IEnumerable<Stage8> Get()
        {
            Stage8 s = new Stage8();
            List<Stage8> st = s.Read9();
            return st;
        }

        // GET: api/Stage8/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stage8
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stage8/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stage8/5
        public void Delete(int id)
        {
        }
    }
}
