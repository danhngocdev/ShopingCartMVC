using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Order
	{
		[Key]
		public int ID { get; set; }
		public int User_ID { get; set; }
		//public string MethodPayMent { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public DateTime? Created { get; set; }
		public int Status { get; set; }
		[ForeignKey("User_ID")]
		public virtual User Users { get; set; }
		public ICollection<OrderDetail> OdersDetail { get; set; }
	}
}
