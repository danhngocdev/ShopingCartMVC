using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using Repository;
using Repository.Interface;
using Service.Interface;

namespace Service
{
	public class RoleActionService : IServices<RoleAction>
	{
		private IRepository<RoleAction> repository;
		public RoleActionService()
		{
			repository = new RoleActionRepository(new DBEntityContext());
		}
		public IEnumerable<RoleAction> GetAll()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<RoleAction> Search(string searchString, int Page, int Pagesize)
		{
			return repository.Search(searchString, Page, Pagesize);
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
