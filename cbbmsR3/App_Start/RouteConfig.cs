using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace cbbmsR3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //Home Controler Routes
            routes.MapRoute(name: "Home", url: "", defaults: new { Controller = "Home", action = "Index" });
            routes.MapRoute(name: "About", url: "About", defaults: new { Controller = "Home", action = "About" });
            routes.MapRoute(name: "Contacts", url: "Contact", defaults: new { Controller = "Home", action = "Contact" });
            routes.MapRoute(name: "Admin", url: "Admin/Default/", defaults: new { Controller = "Default", action = "Index" });
            //routes.MapRoute(name: "Sample2", url: "sample2", defaults: new { Controller = "Home", action = "sample2" });

            //Account Controller Routes
            routes.MapRoute(name: "Register", url: "Register", defaults: new { Controller = "Account", action = "Register" });
            routes.MapRoute(name: "Manage", url: "Manage", defaults: new { Controller = "Account", action = "Manage" });
            routes.MapRoute(name: "Login", url: "Login", defaults: new { Controller = "Account", action = "Login" });

            //FeedBack Controler Route

            //routes.MapRoute(name: "Feedback", url: "Feedback", defaults: new { Controller = "FeedBack", action = "Details" });

            //Default Route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
