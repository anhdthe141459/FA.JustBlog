using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FA.JustBlog.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "List of Post",
                url: "post",
                defaults: new { controller = "Home", action = "ListPost" }
            );
            routes.MapRoute(
                name: "Get Post By Title",
                url: "post/{url}",
                defaults: new { controller = "Home", action = "GetPostByTitle" }
            );
            routes.MapRoute(
                name: "Get Post By TagId",
                url: "posts/{Id}",
                defaults: new { controller = "Home", action = "GetPostByTagId" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
