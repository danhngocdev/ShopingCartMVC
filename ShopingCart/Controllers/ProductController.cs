using DAL;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCart.Controllers
{
    public class ProductController : Controller
    {
        private ProductService productService;
        private CategoryService categoryService;

        public ProductController()
        {
            categoryService = new CategoryService();
            productService = new ProductService();
        }
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.ListCategory = categoryService.GetAll();
            ViewBag.ListProduct = productService.GetAll();
            return View();
        }
        public ActionResult CategoryViewDetail(int id)
        {
            ViewBag.ListCategory = categoryService.GetAll();
            var category = categoryService.GetById(id);
            ViewBag.category = category;
            List<Product> lst = new List<Product>();
            using (var context = new DBEntityContext())
            {
                lst = context.Products.Where(s => s.Category_ID == id).ToList();
            }
            return View(lst);
        }
        public ActionResult Detail(int id)
        {
            var product = productService.GetById(id);
            ViewBag.Category = productService.GetById(product.Category_ID);
            return View(product);
        }

    }
}