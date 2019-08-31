using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCart.Controllers
{
    public class OrderController : Controller
    {
		private UserService _userService;
		private OrderService _orderService;
		private OrderDetailService _orderDetailService;
		public OrderController()
		{
			_userService = new UserService();
			_orderService = new OrderService();
			_orderDetailService = new OrderDetailService();
		}
        // GET: Order
        public ActionResult Index()
        {
			var t = Session["CartSession"];
			if (Session["User"] != null)
			{
				int id =int.Parse(Session["User"].ToString());
				var user =_userService.GetById(id);
				ViewBag.User = user;
			}
			

            return View();
        }
		[HttpPost]
		public ActionResult Index(Order order)
		{
			if (ModelState.IsValid)
			{
				var cart =(List<CartItem>) Session["CartSession"];
				var orderDetails = new List<OrderDetail>();
				foreach (var item in cart)
				{
					var orderDetail = new OrderDetail {
						Price =float.Parse( item.Product.Price.ToString()),
					Product_Id=item.Product.Id,
					Quantity=item.Quantity,
					Total= float.Parse(item.Product.Price.ToString())*item.Quantity
					};
					orderDetails.Add(orderDetail);
				}
			var result=	_orderDetailService.Inserts(order,orderDetails);
				if (result > 0)
				{
					TempData["message"] = "Added";
					Session["CartSession"] = null;
				}
				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index","Home");
			}
			return View("Index");
		}
    }
}