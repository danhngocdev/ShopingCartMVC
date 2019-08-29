using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCart.Controllers
{
    public class ContactController : Controller
    {
        private ContactService service;
        private FeedBackService feedBack;
        public ContactController()
        {
            feedBack = new FeedBackService();
            service = new ContactService();
        }
        // GET: Contact
        public ActionResult Index()
        {
            return View(service.GetContact());
        }
        public JsonResult Send(string name, string email,string phone,string message)
        {
            var fb = new FeedBack();
            fb.FullName = name;
            fb.Email = email;
            fb.Phone = int.Parse(phone);
            fb.Content = message;
            fb.Createad = DateTime.Now;
            fb.Status = true;
            feedBack.Insert(fb);
            return Json(new
            {
                status = true
            });

        }
    }
}