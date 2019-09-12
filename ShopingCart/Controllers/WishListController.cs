using System;
using Service;
using System.Web.Mvc;
using Model;

namespace ShopingCart.Controllers
{
	public class WishListController : Controller
	{
		private WishListService wishListService;
		// GET: WishList
		public WishListController()
		{
			wishListService = new WishListService();
		}
		public ActionResult Index()
		{
			return View(wishListService.GetAll());
		}
		[HttpPost]
		public ActionResult Remove(WishList c)
		{
			if (Session["User"] != null)
			{
				var data = (User)Session["User"];
				c.UserID = data.UserId;
				wishListService.Delete(c);
				return Json(new
				{
					status = true
				});
			}

			return Json(new
			{
				status = false

			});
		}
	}
}