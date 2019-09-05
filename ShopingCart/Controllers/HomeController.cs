﻿using DAL;
using Model;
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
        private const string CartSession = "CartSession";
        private MenuService menuService;
        private ProductService productService;
        private SliderService sliderService;
        private CategoryService categoryService;

        public HomeController()
        {
            sliderService = new SliderService();
            productService = new ProductService();
            menuService = new MenuService();
            categoryService = new CategoryService();
            
        }
        public ActionResult Index()
        {

            ViewBag.ListProductHot = productService.ListProductHot();
            ViewBag.ListProductNew = productService.ListProductNew();
            ViewBag.ListProductSale = productService.ListProductSale();
            return View();
        }
        public PartialViewResult LoadChilden(int parentID)
        {
            List<Category> lst = new List<Category>();
            using( var context = new DBEntityContext())
            {
                lst = context.Categories.Where(s => s.ParentID == parentID).ToList();
            }
            ViewBag.Count = lst.Count();
            return PartialView("LoadChilden",lst);
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            List<Category> lst = new List<Category>();
            using (var context = new DBEntityContext())
            {
                lst = context.Categories.Where(s => s.ParentID == null).ToList();
            }
            return PartialView(lst);
        }

        [ChildActionOnly]
        public ActionResult Slider()
        {
            return PartialView(sliderService.GetAll());
        }

        [ChildActionOnly]
        public ActionResult HeaderCart()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
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