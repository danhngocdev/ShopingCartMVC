using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using PagedList;
using Repository.Interface;

namespace Repository
{
	public class RoleActionRepository:IRepository<RoleAction>
	{
		private DBEntityContext context;
		public RoleActionRepository(DBEntityContext context)
		{
			this.context = context;
		}
		public IEnumerable<RoleAction> GetAll()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<RoleAction> Search(string searchString, int Page, int Pagesize)
		{
			var model = context.RoleActions.ToList();
			return model.OrderByDescending(x => x.RoleId).ToPagedList(Page, Pagesize);
		}

		public int Insert(RoleAction t)
		{
			throw new NotImplementedException();
		}

		public int Update(RoleAction t)
		{
			throw new NotImplementedException();
		}

		public int Delete(int id)
		{
			throw new NotImplementedException();
		}

		public RoleAction GetById(int id)
		{
			throw new NotImplementedException();
		}

		public RoleAction GetByUserName(string UserName)
		{
			throw new NotImplementedException();
		}

		public bool Login(string username, string password)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<RoleAction> ListProductHot()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<RoleAction> ListProductSale()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<RoleAction> ListProductNew()
		{
			throw new NotImplementedException();
		}

		public Contact GetContact()
		{
			throw new NotImplementedException();
		}
	}
}
