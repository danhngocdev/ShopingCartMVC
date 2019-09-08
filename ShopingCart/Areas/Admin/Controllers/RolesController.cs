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
			roleActionService = new RoleActionService();
			roleService = new RoleService();

		}

		// GET: Admin/Roles
		public ActionResult Index()
		{
			return View(roleService.GetAll());
		}

		public ActionResult DetailRole(int id, string searchString, int Page = 1, int PageSize = 10)
		{
			Session["RoleIdDelete"] = id;
			ViewBag.RoleId = id;
			ViewBag.Role = roleService.GetById(id);
			ViewBag.searchString = searchString;
			return View(roleActionService.ListCurrentRole(id,searchString,Page,PageSize));
		}

		public ActionResult Actions(int id, string searchString, int Page = 1, int PageSize = 10)
		{
			Session["RoleIdAddNew"] = id;
			ViewBag.RoleId = id;
			ViewBag.searchString = searchString;
			return View(roleActionService.ListActions(id,searchString,Page,PageSize));
		}
		[HttpPost]
		public ActionResult AddActions(int[] checkbox)
		{
			int roleId = int.Parse(Session["RoleIdAddNew"].ToString());
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
				var result = roleActionService.AddActions(listRoleActions);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else
				{
					TempData["message"] = "false";
				}
			}
			return RedirectToAction("Actions", new { id = roleId });
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

				var result = roleActionService.RemoveActions(listRoleActions);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else
				{
					TempData["message"] = "false";
				}
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
				var result = roleService.Insert(role);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else if (result == -2)
				{
					ModelState.AddModelError("RoleName", "Role Name Đã Tồn Tại");
					return View();
				}
				else
				{
					TempData["message"] = "false";
				}
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
				var result = roleService.Update(role);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else if (result == -2)
				{
					ModelState.AddModelError("RoleName", "Role Name Đã Tồn Tại");
					return View();
				}
				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index");
			}
			return View(role);
		}

		// GET: Admin/Roles/Delete/5
		public ActionResult Delete(int id)
		{
			var result = roleService.Delete(id);
			if (result > 0)
			{
				TempData["message"] = "Added";
			}else if (result == -1)
			{
				TempData["message"] = "Ex";
				TempData["data"] = "Role đang được sử dụng! Bạn không thể xóa";
			}
			else
			{
				TempData["message"] = "false";
			}
			return RedirectToAction("Index");
		}

	}
}
