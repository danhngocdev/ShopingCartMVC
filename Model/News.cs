using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class News
    {
        [Key]
        public int  ID { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Images { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }

        public bool Status { get; set; }
    }
}
