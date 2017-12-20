using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AfoCompanion
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Weapons",
                url: "Weapons",
                defaults: new { controller = "Home", action = "Weapons" }
            );

            routes.MapRoute(
                name: "Photos",
                url: "Photos",
                defaults: new { controller = "Home", action = "Photos" }
            );

            routes.MapRoute(
                name: "Videos",
                url: "Videos",
                defaults: new { controller = "Home", action = "Videos" }
            );

            routes.MapRoute(
                name: "WarGuide",
                url: "WarGuide",
                defaults: new { controller = "Home", action = "WarGuide" }
            );

            routes.MapRoute(
                name: "WC",
                url: "WC",
                defaults: new { controller = "Home", action = "WC" }
            );

            routes.MapRoute(
                name: "Stats",
                url: "Stats",
                defaults: new { controller = "Home", action = "Stats" }
            );

            routes.MapRoute(
                name: "StatsResult",
                url: "StatsResult",
                defaults: new { controller = "Home", action = "StatsPost" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
