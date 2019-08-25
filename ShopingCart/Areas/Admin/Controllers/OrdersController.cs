using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;
using ShopingCart.Models;

namespace ShopingCart.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
		private OrderService _orderService;
		private OrderDetailService _orderDetailService;
		public OrdersController()
		{
			_orderService = new OrderService();
			_orderDetailService = new OrderDetailService();
		}

		// GET: Admin/Orders
		public ActionResult Index()
        {
            return View(_orderService.GetAll());
        }
		[HttpPost]
		public ActionResult Details(Order order)
		{
			_orderService.Update(order);
			return RedirectToAction("Index");
			
			
		}
		// GET: Admin/Orders/Details/5
		public ActionResult Details(int id)
        {  
			
           var orderDetail = _orderDetailService.GetAll(id);
			ViewBag.Order = _orderService.GetById(orderDetail[0].Oder_ID);
			double total = 0;
			foreach (var item in orderDetail)
			{
				total += item.ToltalPrice;
			}
			ViewBag.ToltalPrice = total;
			if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        
        //// GET: Admin/Orders/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.User_ID = new SelectList(db.Users, "UserId", "UserName", order.User_ID);
        //    return View(order);
        //}

        // POST: Admin/Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,User_ID,Name,Email,Phone,Address,Created,Status")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(order).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.User_ID = new SelectList(db.Users, "UserId", "UserName", order.User_ID);
        //    return View(order);
        //}

        // GET: Admin/Orders/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        // POST: Admin/Orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Order order = db.Orders.Find(id);
        //    db.Orders.Remove(order);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
