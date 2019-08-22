using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCart.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private UserService userService;
        public LoginController()
        {
            userService = new UserService();
        }

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model, bool isLoginAdmin = false)
        {


            if (ModelState.IsValid)
            {

               var res = userService.Login(model,true);
                if (res>0)
                {
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else
                {
                    ModelState.AddModelError("", "False");
                }


            }
            
            return View("Index");
           
            
        }
    }
}