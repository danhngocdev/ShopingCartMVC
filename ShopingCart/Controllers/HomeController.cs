using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCart.Controllers
{
    public class HomeController : Controller
    {
        private MenuService menuService;
        private ProductService productService;
        public HomeController()
        {
            productService = new ProductService();
            menuService = new MenuService();
        }
        public ActionResult Index()
        {
            ViewBag.ListProductHot = productService.ListProductHot();
            ViewBag.ListProductNew = productService.ListProductNew();
            ViewBag.ListProductSale = productService.ListProductSale();
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            
            return PartialView(menuService.GetAll());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}