using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
 public	class OrderDetailDTO
	{
		public int Product_Id { get; set; }
		public int Oder_ID { get; set; }
		public double Price { get; set; }
		public double Quantity { get; set; }
		public double Total { get; set; }
		public string NameProduct { get; set; }
		public string Images { get; set; }
		public double? Sale_Price { get; set; }
		public double ToltalPrice { get; set; }
	}
}
