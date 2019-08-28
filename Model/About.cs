using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class About
    {   
        public int ID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Detail { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifileDate { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
    }
}
