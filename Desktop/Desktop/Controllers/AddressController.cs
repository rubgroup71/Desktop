using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AddressController : ApiController
    {
        // GET: api/Address
        public IEnumerable<Address> Get()
        {
            Address C = new Address();
            List<Address> CUS = C.Show();
            return CUS;
        }

        // GET: api/Address/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Address
        public void Post([FromBody]Address A)
        {
            A.insertA();

        }
        [HttpPost]
        [Route("api/Addressapp")]
        public void appPost([FromBody]string A)
        {

            var c = A.Split(new Char[] {',', '.', ':', '"', '{', '}', '\"' });
            List<string> s = new List<string>();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] != "")
                {
                    s.Add(c[i]);
                }
            }
            Address a = new Address(s[1], s[3], s[5], s[7], s[9], s[11], s[13]);
            a.insertA();

        }
        // PUT: api/Address/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Address/5
        public void Delete(int id)
        {
        }
    }
}
