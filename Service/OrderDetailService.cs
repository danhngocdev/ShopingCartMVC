using DAL;
using Model;
using Model.ViewModel;
using Repository;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public class OrderDetailService : IOrderDetailService
	{
		private OrderDetailRepository repository;
		public OrderDetailService()
		{
			repository = new OrderDetailRepository(new DBEntityContext());
		}
		public IList<OrderDetailDTO> GetAll(int id)
		{
			return repository.GetAll(id);
		}

		public int Update(OrderDetail t)
		{
			return repository.Update(t);
		}
	}
}
