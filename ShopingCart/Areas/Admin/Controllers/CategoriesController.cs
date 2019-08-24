using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace ShopingCart.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryService _categoryService;
        public CategoriesController()
        {
            _categoryService = new CategoryService();
        }

        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(_categoryService.GetAll());
        }
        
      

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Slug,ParentID,Status,CreatedDate,ModifileDate")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.CreatedDate = DateTime.Now;
                _categoryService.Insert(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

       
        public ActionResult Edit(int id)
        {
          
            Category category = _categoryService.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Slug,ParentID,Status,CreatedDate,ModifileDate")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.ModifileDate = DateTime.Now;
                _categoryService.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        
        [HttpGet, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
