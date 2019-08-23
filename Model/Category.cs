using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
       
        public string Name { get; set; }
        [Required(ErrorMessage = "Slug không được để trống")]
        public string Slug { get; set; }
        
        public int? ParentID { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifileDate { get; set; }
        public ICollection<Product> Products { get; set; }
        [ForeignKey("ParentID")]
        public Category Categorys { get; set; }
    }
}
