using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project_63133655
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Action",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "GioiThieu_63133655", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
