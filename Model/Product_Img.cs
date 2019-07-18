using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product_Img
    {
        [Key]
        public int ID { get; set; }
        public string Img { get; set; }
        public int Pord_Id { get; set; }
        [ForeignKey("Prod_Id")]
        public Product Products { get; set; }
        
    }
}
