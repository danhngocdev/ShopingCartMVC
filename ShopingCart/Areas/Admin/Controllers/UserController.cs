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
    public class UserController : BaseController
    {
	    private RoleService roleService;
        private UserService userService;
        public UserController()
        {
			roleService=new RoleService();
            userService = new UserService();
        }
		// GET: Admin/User
		[HasCredential(ActionId = 23)]
		public ActionResult Index(string searchString, int Page = 1, int PageSize = 15)
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
		[HasCredential(ActionId = 24)]
		public ActionResult Edit(int id)
		{
			var user = userService.GetById(id);
			ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName",user.RoleId);
			ViewBag.user = userService.GetById(id);
			return View(user);
		}
		[HttpPost]
		[ValidateInput(false)]
		[ValidateAntiForgeryToken]
		[HasCredential(ActionId = 24)]
		public ActionResult Edit(User user)
		{
			if (ModelState.IsValid)
			{
				user.Password = Encryptor.MD5Hash(user.Password);
				var result = userService.Update(user);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}else if (result == -1)
				{
					ModelState.AddModelError("Username", "Tài Khoản Đã Tồn Tại");
					ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName");
					return View();
				}
				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index");
			}
			ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName");
			ViewBag.user = userService.GetById(user.UserId);
			return View();
		}

	}
}