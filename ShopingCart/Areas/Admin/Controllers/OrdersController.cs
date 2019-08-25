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
			var result= _orderService.Update(order);
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

        
       
    }
}
