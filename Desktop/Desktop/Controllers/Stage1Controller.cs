using Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Desktop.Controllers
{
    public class Stage1Controller : ApiController
    {
        // GET: api/Stage1
        public IEnumerable<stage1> Get()
        {
            Stage1 s = new Stage1();
            List<Stage1> ho = s.Read();
            return ho;
            ;
        }

        // GET: api/Stage1/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stage1
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stage1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stage1/5
        public void Delete(int id)
        {
        }
    }
}
