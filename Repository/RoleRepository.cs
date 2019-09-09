using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using Repository.Interface;

namespace Repository
{
public	class RoleRepository:IRepository<Role>
	{
		private DBEntityContext context;
		public RoleRepository(DBEntityContext context)
		{
			this.context = context;
		}
		public IEnumerable<Role> GetAll()
		{
			return context.Roles.ToList();
		}

		public IEnumerable<Role> Search(string searchString, int Page, int Pagesize)
		{
			throw new NotImplementedException();
		}

		public int Insert(Role t)
		{
			context.Roles.Add(t);
			return context.SaveChanges();
		}

		public int Update(Role t)
		{
			context.Entry(t).State = EntityState.Modified;
			return context.SaveChanges();
		}

		public int Delete(int id)
		{
			var currentItem = context.Roles.Find(id);
			if(currentItem!=null)context.Roles.Remove(currentItem);
			return context.SaveChanges();
		}

		public Role GetById(int id)
		{
			return context.Roles.Find(id);
		}

		public Role GetByUserName(string UserName)
		{
			throw new NotImplementedException();
		}

		public bool Login(string username, string password)
		{
			throw new NotImplementedException();
		}


		public Contact GetContact()
		{
			throw new NotImplementedException();
		}
	}
}
