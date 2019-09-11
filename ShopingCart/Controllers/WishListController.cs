using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}