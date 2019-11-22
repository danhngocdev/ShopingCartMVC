using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCart.Controllers
{
    public class ProjectedController : Controller
    {
        private ProjectService projectService;
        public ProjectedController()
        {
            projectService = new ProjectService();
        }
        // GET: Projected
        public ActionResult Index()
        {
            return View(projectService.GetAll());
        }
        public ActionResult Detail(int id)
        {
            return View(projectService.GetById(id));
        }
    }
}