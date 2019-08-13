using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Slider
    {
        [Key]
        public int ID { get; set; }
        public string Images { get; set; }

        public string Link { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime? Created { get; set; }
    }
    
}
