using Model;
using Service;
using ShopingCart.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCart.Controllers
{
    public class LoginController : Controller
    {
		private UserService _userService;
		public LoginController()
		{
			_userService = new UserService();
		}
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Index(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				var res = _userService.Login(model.UserName, Encryptor.MD5Hash(model.Password));
				if (res)
				{

					var user = _userService.GetByUserName(model.UserName);
					Session["User"] = user;
					return RedirectToAction("Index", "Order");
				}
				else
				{
					ModelState.AddModelError("", "Login sai");
				}
			}
			return View("Index");
		}
		public ActionResult LogOut()
		{
			Session["User"] = null;
			return Redirect("/");
		}
    }
}