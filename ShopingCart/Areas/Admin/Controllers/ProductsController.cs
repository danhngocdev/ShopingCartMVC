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
    public class ProductsController : Controller
    {
        private ProductService _productService;
        private CategoryService _categoryService;
        public ProductsController()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
        }
        // GET: Admin/Products
        public ActionResult Index()
        {
            return View(_productService.GetAll());
        }

       
        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(_categoryService.GetAll(), "ID", "Name");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Slug,Content,Images,Price,Sale_Price,Category_ID,MoreImages,Created,ModifileDate,Status")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Insert(product);
                return RedirectToAction("Index");
            }

            ViewBag.Category_ID = new SelectList(_categoryService.GetAll(), "ID", "Name", product.Category_ID);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int id)
        {
           
            Product product = _productService.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_ID = new SelectList(_categoryService.GetAll(), "ID", "Name", product.Category_ID);
            return View(product);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Slug,Content,Images,Price,Sale_Price,Category_ID,MoreImages,Created,ModifileDate,Status")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.Category_ID = new SelectList(_categoryService.GetAll(), "ID", "Name", product.Category_ID);
            return View(product);
        }

       

        // POST: Admin/Products/Delete/5
        [HttpGet, ActionName("Delete")]
      
        public ActionResult DeleteConfirmed(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
