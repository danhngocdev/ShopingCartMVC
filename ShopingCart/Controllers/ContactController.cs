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
        public ContactController()
        {
            service = new ContactService();
        }
        // GET: Contact
        public ActionResult Index()
        {
            return View(service.GetContact());
        }
    }
}