using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using PagedList;
using Repository.Interface;
using Action = Model.Action;

namespace Repository
{
	public class RoleActionRepository : IRoleActionRepository
	{
		private DBEntityContext context;
		public RoleActionRepository(DBEntityContext context)
		{
			this.context = context;
		}

		public List<Action> ListActions(int id)
		{
			var currentActions = context.RoleActions.Where(x => x.RoleId.Equals(id)).ToList();
			var listActions = context.Actions.ToList();
			foreach (var item in currentActions)
			{
				listActions.Remove(context.Actions.SingleOrDefault(x=>x.ActionId.Equals(item.ActionId)));
			}

			return listActions;
		}

		public List<Action> ListCurrentRole(int id)
		{
			var currentActions = context.RoleActions.Where(x => x.RoleId.Equals(id)).ToList();
			List<Action> listActions = new List<Action>();
			if (currentActions.Count==0) return new List<Action>();
			foreach (var item in currentActions)
			{
				var current = context.Actions.SingleOrDefault(s => s.ActionId.Equals(item.ActionId));
				listActions.Add(current);
			}
			return listActions;
		}

		public int AddActions(List<RoleAction> items)
		{
			context.RoleActions.AddRange(items);
			return context.SaveChanges();
		}

		public int RemoveActions(List<RoleAction> items)
		{
			var listRoleAction = new List<RoleAction>();
			foreach (var item in items)
			{
				listRoleAction.Add(context.RoleActions.FirstOrDefault(s=>s.ActionId.Equals(item.ActionId)&&s.RoleId.Equals(item.RoleId)));
			}
			context.RoleActions.RemoveRange(listRoleAction);
			return context.SaveChanges();
		}
	}
}
