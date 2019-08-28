using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCart.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;
        public UserController()
        {
            userService = new UserService();
        }
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
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
        
        
    }
}