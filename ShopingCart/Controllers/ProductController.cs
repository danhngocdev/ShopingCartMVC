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
        public ActionResult CategoryViewDetail(int id, int pageIndex = 1, int pageSize = 1)
        {

            ViewBag.ListCategory = categoryService.GetAll();

            var total = productService.GetAll().Count();
            var category = categoryService.GetById(id);
            ViewBag.Category = category;
            var model = productService.ListProductGetByCategory(id,pageIndex,pageSize);
            ViewBag.Total = total;
            ViewBag.Page = pageIndex;
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(total / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.Maxpage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = pageIndex + 1;
            ViewBag.Prev = pageIndex - 1;
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            var product = productService.GetById(id);
            ViewBag.Category = productService.GetById(product.Category_ID);
            return View(product);
        }

    }
}