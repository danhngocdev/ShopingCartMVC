﻿using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ShopingCart.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private CategoryService service;
        public CategoryController()
        {
            service = new CategoryService();
        }
        public ActionResult Index()
        {
            return View(service.GetAll());
        }
        public ActionResult Get(int id)
        {
            return View(service.GetById(id));
        }
        


    }
}