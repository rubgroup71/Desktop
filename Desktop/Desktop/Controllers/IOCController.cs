using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace Desktop.Controllers
{
    public class IOCController : ApiController
    {
        // GET: api/IOC
        public IEnumerable<IOC> Get(string email)
        {
            IOC IO = new IOC();
            List<IOC> a = IO.FilterIOC(email);
            return a;

        }

        // GET: api/IOC/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/IOC
        //public void Post([FromBody]IOC IOC)
        //{
        //    IOC.InsertIOC();
        //}

        // PUT: api/IOC/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/IOC/5
        public void Delete(int id)
        {
        }
    }
}
