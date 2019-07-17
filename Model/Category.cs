using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [RegularExpression(@"[\w]+",ErrorMessage = "Tên danh mục không được chức các ký tự đặc biệt")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Slug không được để trống")]
        public string Slug { get; set; }
        [Required]
        public int ParentID { get; set; }
    }
}
