﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ShopingCart.Common;

namespace ShopingCart
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
	        if (Server.GetLastError() is HttpException error && !string.IsNullOrWhiteSpace( error.Message))
	        {
				if (error.GetHttpCode() == 404)
				{
					Server.ClearError();
					Context.Response.Redirect("/Home/Error404");
				}
				else
				{
					Context.ClearError();
					Context.Response.Redirect("https://localhost:44347/Home/Error500");
				}
			}
        }
	}
}
