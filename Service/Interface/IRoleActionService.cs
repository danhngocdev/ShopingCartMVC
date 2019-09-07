using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Action = Model.Action;

namespace Service.Interface
{
	public interface IRoleActionService
	{
		List<Action> ListActions(int id);
		List<Action> ListCurrentRole(int id);
		int AddActions(List<RoleAction> items);
		int RemoveActions(List<RoleAction> items);
	}
}
