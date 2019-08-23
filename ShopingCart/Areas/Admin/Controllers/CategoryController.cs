using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCart.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryService category;
        public CategoryController()
        {
            category = new CategoryService();
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(category.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(category.GetAll(), "ID", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category c)
        {
            if (ModelState.IsValid)
            {

                category.Insert(c);
                return RedirectToAction("Index");
            }
            ViewBag.ParentID = new SelectList(category.GetAll(), "ID", "Name");
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.ParentID = new SelectList(category.GetAll(), "ID", "Name",category.GetById(id).ParentID);
            return View(category.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category c)
        {
            if (ModelState.IsValid)
            {
                category.Update(c);
                return RedirectToAction("Index");
            }
           
            return View();

        }
        public ActionResult Delete(int id)
        {
            category.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}