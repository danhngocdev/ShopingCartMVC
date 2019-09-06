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
using Action = Model.Action;

namespace Service
{
	public class RoleActionService : IRoleActionService
	{
		private IRoleActionRepository repository;
		public RoleActionService()
		{
			repository = new RoleActionRepository(new DBEntityContext());
		}

		public List<Action> ListActions(int id)
		{
			return repository.ListActions(id);
		}

		public List<Action> ListCurrentRole(int id)
		{
			return repository.ListCurrentRole(id);
		}

		public int AddActions(List<RoleAction> items)
		{
			return repository.AddActions(items);
		}

		public int RemoveActions(List<RoleAction> items)
		{
			return repository.RemoveActions(items);
		}
	}
}
