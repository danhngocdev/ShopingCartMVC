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
    public class RolesController : Controller
    {
	    private RoleActionService roleActionService;
		private RoleService roleService;
		
		public RolesController()
		{
			roleActionService=new RoleActionService();
			roleService = new RoleService();
			
		}

		// GET: Admin/Roles
		public ActionResult Index()
        {
            return View(roleService.GetAll());
        }


		public ActionResult DetailRole(int id)
		{
			Session["RoleIdDelete"] = id;
			ViewBag.RoleId = id;
			return View(roleActionService.ListCurrentRole(id));
		}

		public ActionResult Actions(int id)
		{
			Session["RoleIdAddNew"] = id;
			ViewBag.RoleId = id;
			return View(roleActionService.ListActions(id));
		}
		[HttpPost]
		public ActionResult AddActions(int[] checkbox)
		{
			int roleId = int.Parse(Session["RoleIdAddNew"].ToString());
			if (checkbox != null)
			{
				var listRoleActions=new List<RoleAction>();
				foreach (var item in checkbox)
				{
					var currentItem=new RoleAction();
					currentItem.RoleId = roleId;
					currentItem.ActionId = item;
					currentItem.IsTrue = true;
					listRoleActions.Add(currentItem);
				}

				roleActionService.AddActions(listRoleActions);
			}
			return RedirectToAction("Actions",new {id= roleId });
		}
		[HttpPost]
		public ActionResult RemoveActions(int[] checkbox)
		{
			int roleId = int.Parse(Session["RoleIdDelete"].ToString());
			if (checkbox != null)
			{
				var listRoleActions = new List<RoleAction>();
				foreach (var item in checkbox)
				{
					var currentItem = new RoleAction();
					currentItem.RoleId = roleId;
					currentItem.ActionId = item;
					listRoleActions.Add(currentItem);
				}

				roleActionService.RemoveActions(listRoleActions);
			}
			return RedirectToAction("DetailRole", new { id = roleId });
		}
		// GET: Admin/Roles/Create
		public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleId,RoleName,Description")] Role role)
        {
            if (ModelState.IsValid)
            {
	            roleService.Insert(role);
                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: Admin/Roles/Edit/5
        public ActionResult Edit(int id)
        {
	        Role role = roleService.GetById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleId,RoleName,Description")] Role role)
        {
            if (ModelState.IsValid)
            {
	            roleService.Update(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Admin/Roles/Delete/5
        public ActionResult Delete(int id)
        {
	        roleService.Delete(id);
			return RedirectToAction("Index");
		}

    }
}
