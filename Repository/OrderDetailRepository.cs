using DAL;
using Model;
using Model.ViewModel;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class OrderDetailRepository :  IOrderDetailRepository
	{
		private DBEntityContext context;
		public OrderDetailRepository(DBEntityContext context)
		{
			this.context = context;
		}

		

		public IList<OrderDetailDTO> GetAll(int id)
		{
			var result = (from c in context.OrderDetails
						  join p in context.Products on c.Product_Id equals p.Id
						  where c.Oder_ID == id
						  select new OrderDetailDTO
						  {
							  Images = p.Images,
							  NameProduct = p.Name,
							  Oder_ID = c.Oder_ID,
							  Price = p.Price,
							  Sale_Price = p.Sale_Price,
							  Quantity = c.Quantity,
							  Total = c.Total,
							  Product_Id = p.Id,
							  ToltalPrice=p.Price*c.Total
						  }).ToList();
		
			return result;
		}


		public int Update(OrderDetail t)
		{
			context.Entry(t).State = System.Data.Entity.EntityState.Modified;
			return context.SaveChanges();
		}
	}
}
