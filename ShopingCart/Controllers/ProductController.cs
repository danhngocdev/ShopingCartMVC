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
        public ProductController()
        {
            productService = new ProductService();
        }
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.ListProduct = productService.GetAll();
            return View();
        }
        public ActionResult Detail(int id)
        {
            var product = productService.GetById(id);
            ViewBag.Category = productService.GetById(product.Category_ID);
            return View(product);
        }

    }
}