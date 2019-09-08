using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Model;
using Service;

namespace ShopingCart.Areas.Admin.Controllers
{
    public class FootersController : Controller
    {
		private FooterService footerService;
		public FootersController()
		{
			footerService = new FooterService();
		}
        // GET: Admin/Footers
        public ActionResult Index()
        {
            return View(footerService.GetAll());
        }

        // GET: Admin/Footers/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Content,Status")] Footer footer)
        {
            if (ModelState.IsValid)
            {
				var result= footerService.Insert(footer);
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

            return View(footer);
        }

        // GET: Admin/Footers/Edit/5
        public ActionResult Edit(int id)
        {
            Footer footer = footerService.GetById(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // POST: Admin/Footers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Content,Status")] Footer footer)
        {
            if (ModelState.IsValid)
            {
				var result= footerService.Update(footer);
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
            return View(footer);
        }

        // GET: Admin/Footers/Delete/5
        public ActionResult Delete(int id)
        {
			var result= footerService.Delete(id);
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
