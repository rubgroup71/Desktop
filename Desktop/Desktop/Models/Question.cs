using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Question
    {
        public int QID { get; set; }
        public string Name { get; set; }
        public string Quesstion { get; set; }
        




    
        public Question()
        {

        }

  
        public List<Question> ShowQ()
        {
            DBservices DBS = new DBservices();
            List<Question> C = DBS.ShowQ("ConnectionStringName", "Question");
            return C;
        }

    }
}