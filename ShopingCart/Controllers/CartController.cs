﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;
using System.Web.Script.Serialization;
namespace ShopingCart.Controllers
{
    public class CartController : Controller
    {
        private ProductService productService;
        public CartController()
        {
            productService = new ProductService();
          
        }
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart!=null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public JsonResult Update(string cartModel)
        {
            var JsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var SessionCart = (List<CartItem>)Session[CartSession];
            foreach (var item in SessionCart)
            {
                var jsonitem = JsonCart.SingleOrDefault(x => x.Product.Id == item.Product.Id);
                if (jsonitem!=null)
                {
                    item.Quantity = jsonitem.Quantity;
                }
            }
            Session[CartSession] = SessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(int id)
        {
            var SessionCart = (List<CartItem>)Session[CartSession];
            SessionCart.RemoveAll(x => x.Product.Id == id);
            Session[CartSession] = SessionCart;
            return Json(new
            {
                status = true
            });

        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });

        }
        public ActionResult AddItem(int productID,int quantity)
        {
            var product = productService.GetById(productID);
            var cart = Session[CartSession];
            if (cart !=null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x=>x.Product.Id == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.Id == productID)
                        {
                            item.Quantity += quantity;
                        }

                    }

                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    
                    list.Add(item);
                }

                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        
    }
}