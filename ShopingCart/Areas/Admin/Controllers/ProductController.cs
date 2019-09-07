using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopingCart.Common;

namespace ShopingCart.Areas.Admin.Controllers
{
	public class ProductController : Controller
	{
		private ProductService product;
		private CategoryService category;
		public ProductController()
		{
			category = new CategoryService();
			product = new ProductService();
		}
		// GET: Admin/Category
		[HasCredential(ActionId = 1)]
		public ActionResult Index()
		{
			return View(product.GetAll());
		}
		[HttpGet]
		public ActionResult Create()
		{
			ViewBag.Category_ID = new SelectList(category.GetAll(), "ID", "Name");
			return View();
		}
		public ActionResult Detail(int id)
		{
			return View(product.GetById(id));
		}
		[HttpPost]
		[ValidateInput(false)]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Product p)
		{
			if (ModelState.IsValid)
			{

				var result = product.Insert(p);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index");
			}
			ViewBag.Category_ID = new SelectList(category.GetAll(), "ID", "Name");
			return View();
		}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			ViewBag.Category_ID = new SelectList(product.GetAll(), "ID", "Name", product.GetById(id).Category_ID);
			return View(product.GetById(id));
		}
		[HttpPost]
		[ValidateInput(false)]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Product p)
		{
			if (ModelState.IsValid)
			{
				var result = product.Update(p);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index");
			}
			ViewBag.Category_ID = new SelectList(product.GetAll(), "ID", "Name", product.GetById(p.Category_ID));
			return View();

		}
		public ActionResult Delete(int id)
		{
			var result = product.Delete(id);
			if (result > 0)
			{
				TempData["message"] = "Added";
			}
			else
			{
				TempData["message"] = "false";
			}
			return RedirectToAction("Index");
		}

	}
}