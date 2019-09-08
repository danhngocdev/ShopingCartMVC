using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCart.Controllers
{
	public class ResgiterController : Controller
	{
		private UserService userService;

		public ResgiterController()
		{
			userService = new UserService();
		}
		// GET: Resgiter
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		
		public ActionResult Index(User user)
		{
			if (ModelState.IsValid)
			{
				var result = userService.Insert(user);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else if (result == -1)
				{
					ModelState.AddModelError("Username", "Tài Khoản Đã Tồn Tại");
					return View();
				}
				else
				{
					TempData["message"] = "false";
				}
			}
			return RedirectToAction("Index");
		}
	}
}