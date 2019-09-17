using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCart.Areas.Admin.Controllers
{

    public class NewsController : Controller
    {
        private NewsService newsService;
        public NewsController()
        {
            newsService = new NewsService();
        }
        // GET: Admin/News
        public ActionResult Index()
        {
            return View(newsService.GetAll() );
        }
        public ActionResult GetById(int id)
        {
            return View(newsService.GetById(id));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(News n)
        {
            if (ModelState.IsValid)
            {
                newsService.Insert(n);
                
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(newsService.GetById(id));
        }
        public ActionResult Edit(News n)
        {
            if (ModelState.IsValid)
            {
                newsService.Update(n);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            newsService.Delete(id);
            return RedirectToAction("Index");
        }
           
    }
}