using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCart.Areas.Admin.Controllers
{
	public class SliderController : Controller
	{
		private SliderService sliderService;
		public SliderController()
		{
			sliderService = new SliderService();
		}
		// GET: Admin/Slider
		public ActionResult Index()
		{
			return View(sliderService.GetAll());
		}
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(Slider s)
		{
			if (ModelState.IsValid)
			{
				var result = sliderService.Insert(s);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else
				{
					TempData["message"] = "false";
				}
			return	RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			return View(sliderService.GetById(id));
		}
		public ActionResult Edit(Slider s)
		{
			if (ModelState.IsValid)
			{
				var result = sliderService.Update(s);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else
				{
					TempData["message"] = "false";
				}
			return	RedirectToAction("Index");
			}
			return View();
		}
		public ActionResult Delete(int id)
		{
			var result = sliderService.Delete(id);
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