using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KonsorcjumLekarzy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "mainRoute",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
                );

            routes.MapRoute(
                name: "authorize",
                url: "authorize", 
                defaults: new { controller = "Home", action = "UserAuthorize" }
                );

            routes.MapRoute(
                name: "newAccount",
                url: "account",
                defaults: new { controller = "Account", action = "Register" }
                );

            //SEO
            routes.MapRoute("Robots", "robots.txt", new { controller = "Seo", action = "Robots" });

            //Error
            routes.MapRoute(name: "Error404", url: "Error/Error404", defaults: new { controller = "Error", action = "Error404" });
            
        }
    }
}
