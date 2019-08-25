using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class OrderDetail
	{
		public int ID { get; set; }
		public int Product_Id { get; set; }
		public int Oder_ID { get; set; }
		public float Price { get; set; }
		public double Quantity { get; set; }
		public float Total { get; set; }
		//public string PayMentMethod { get; set; }
		[ForeignKey("Oder_ID")]
		public  Order Order { get; set; }
		[ForeignKey("Product_Id")]
		public Product Product { get; set; }
	}

}
