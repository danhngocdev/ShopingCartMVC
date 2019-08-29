using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string Images { get; set; }
        [Required (ErrorMessage ="Vui Lòng Nhập giá sản phẩm")]
        [Range(0,double.MaxValue,ErrorMessage ="giá không được âm")]
        public double Price { get; set; }
       
        public double? Sale_Price { get; set; }
        public int Category_ID { get; set; }
        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? ModifileDate { get; set; }
        public bool? Status { get; set; }
        public bool? TopHot { get; set; }

        [ForeignKey("Category_ID")]
        public virtual Category Categorys { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
