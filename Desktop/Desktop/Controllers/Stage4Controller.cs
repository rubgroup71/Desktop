using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace Desktop.Controllers
{
    public class Stage4Controller : ApiController
    {
        // GET: api/Stage4
        public IEnumerable<Stage4> Get()
        {
            Stage4 s = new Stage4();
            List<Stage4> st = s.Read5();
            return st;
        }

        // GET: api/Stage4/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stage4
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stage4/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stage4/5
        public void Delete(int id)
        {
        }
    }
}
