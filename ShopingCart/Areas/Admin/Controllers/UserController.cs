using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using ShopingCart.Common;

namespace ShopingCart.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
	    private RoleService roleService;
        private UserService userService;
        public UserController()
        {
			roleService=new RoleService();
            userService = new UserService();
        }
        // GET: Admin/User
        public ActionResult Index(string searchString, int Page = 1, int PageSize = 2)
        {
	        ViewBag.searchString = searchString;
			return View(userService.Search(searchString,Page,PageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                if(userService.GetAll().Any(x=>x.UserName == user.UserName ))
                {
                    ModelState.AddModelError("Username", "Tài Khoản Đã Tồn Tại");
                    return View();
                }
                else
                {
                    userService.Insert(user);
                    return  RedirectToAction("Index");
                }

            }
            return View();
        }
		[HttpGet]
		public ActionResult Edit(int id)
		{
			ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName");
			return View(userService.GetById(id));
		}
		[HttpPost]
		[ValidateInput(false)]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(User user)
		{
			if (ModelState.IsValid)
			{
				user.Password = Encryptor.MD5Hash(user.Password);
				var result = userService.Update(user);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index");
			}
			ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName");
			return View();

		}

	}
}