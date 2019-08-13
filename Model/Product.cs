﻿using System;
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
        public string Content { get; set; }
        [Required]
        public string Images { get; set; }
        public float Price { get; set; }
        public float? Sale_Price { get; set; }
        public int Category_ID { get; set; }
        [XmlArray]
        public string MoreImages { get; set; }
        public DateTime? Created { get; set; }
        public bool? Status { get; set; }

        [ForeignKey("Category_ID")]
        public Category Categorys { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
