using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Models
{
    public class Stage10Controller : ApiController
    {
        // GET: api/Stage10
        public IEnumerable<Stage10> Get()
        {
            Stage10 s = new Stage10();
            List<Stage10> st = s.Read11();
            return st;


        }

        // GET: api/Stage10/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stage10
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stage10/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stage10/5
        public void Delete(int id)
        {
        }
    }

   
}
