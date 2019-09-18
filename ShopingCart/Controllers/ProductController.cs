using Service;
using System;
using System.Linq;
using System.Web.Mvc;
using Model;
using PagedList;

namespace ShopingCart.Controllers
{
    public class ProductController : Controller
    {
        private ProductService productService;
        private CategoryService categoryService;
        private WishListService wishListService;


		public ProductController()
        {
            categoryService = new CategoryService();
            productService = new ProductService();
			wishListService=new WishListService();
        }
        // GET: Product
        public ActionResult Index(string searchString, int Page = 1, int PageSize = 10)
        {
	        var user = (User)Session["User"];
	        if (user != null) ViewBag.wishList = wishListService.GetById(user.UserId).ToList();
	        if (user == null) ViewBag.ListNotInUser = Session[Common.CommonConstants.DATA_WISH];
			ViewBag.searchString = searchString;
			ViewBag.ListCategory = categoryService.GetAll();
            ViewBag.ListProduct = productService.Search(searchString,Page,PageSize);
            return View(productService.Search(searchString, Page, PageSize).Where(x=>x.Status==true).ToPagedList(Page, PageSize));
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
            ViewBag.ListProductOther = productService.ListProductSale();
            var product = productService.GetById(id);
            ViewBag.Category = productService.GetById(product.Category_ID);
            return View(product);
        }

    }
}