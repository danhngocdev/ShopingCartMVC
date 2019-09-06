using Model;
using Service;
using ShopingCart.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopingCart.Areas.Admin.Controllers
{
	public class LoginController : Controller
	{
		private LoginService loginService;
		private UserService userService;
		public LoginController()
		{
			loginService = new LoginService();
			userService = new UserService();
		}

		// GET: Admin/Login
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Login(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				var res = userService.Login(model.UserName, Encryptor.MD5Hash(model.Password));
				if (res)
				{

					var user = userService.GetByUserName(model.UserName);
					Session["Admin"] = user.FullName;
					Session.Add(CommonConstants.SESSION_CREDENTIALS, loginService.GetListAction(user.UserName));
					var userSession = new LoginModel
					{
						UserName = user.UserName,

					};

					Session.Add(CommonConstants.USER_SESSION, userSession);

					return RedirectToAction("Index", "HomeAdmin");
				}
				else
				{
					ModelState.AddModelError("", "Login sai");
				}
			}
			return View("Index");
		}

	}
}