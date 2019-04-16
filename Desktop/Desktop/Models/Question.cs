using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Questions
    {
        public int QID { get; set; }
        public string Name { get; set; }
        public string Question { get; set; }
        




    
        public Questions()
        {

        }

  
        public List<Questions> ShowQ(string type)
        {
            DBservices DBS = new DBservices();
            List<Questions> C = DBS.ShowQ(type, "Question");
            return C;
        }

    }
}