using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Repository.Interface;

namespace Repository
{
	public class LoginRepository : ILoginRepository
	{
		private DBEntityContext context;
		public LoginRepository(DBEntityContext context)
		{
			this.context = context;
		}
		public List<int> GetListAction(string userName)
		{
			var user = context.Users.Single(x => x.UserName == userName);
			var data = (from a in context.RoleActions
						join b in context.Roles on a.RoleId equals b.RoleId
						join c in context.Actions on a.ActionId equals c.ActionId
						where b.RoleId == user.RoleId
						select new
						{
							RoleId = a.RoleId,
							ActionId = a.ActionId
						}).AsEnumerable().Select(x => new Model.RoleAction()
						{
							RoleId = x.RoleId,
							ActionId = x.ActionId
						});
			return data.Select(x => x.ActionId).ToList();
		}
	}
}
