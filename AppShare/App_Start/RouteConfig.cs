﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AppShare
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           

            routes.MapRoute(
               name: "Page",
               url: "{controller}/{title}",
               defaults: new { controller = "p", action = "Index", title = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
            /*
            routes.MapRoute(
                name: "Page",
                url: "{controller}/{title}",
                defaults: new { controller = "Home", action = "page", title = UrlParameter.Optional }
            );
            */
        }
    }
}
