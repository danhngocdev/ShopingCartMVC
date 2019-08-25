﻿using System;
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
		public ActionResult Index(string searchString, int Page = 1, int PageSize = 1)
		{
			ViewBag.searchString = searchString;

			return View(_productService.Search(searchString, Page, PageSize));
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
				product.Created = DateTime.Now;
				var result = _productService.Insert(product);
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
				product.ModifileDate = DateTime.Now;
				var result = _productService.Update(product);
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
