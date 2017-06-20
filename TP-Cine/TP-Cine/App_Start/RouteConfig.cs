using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TP_Cine
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Inicio", id = UrlParameter.Optional}
            );
            
            routes.MapRoute(
                name: "Peliculas",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Peliculas", action = "Reserva", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Administracion",
                url: "{controller}/{action}",
                defaults: new { controller = "Administracion", action = "Inicio", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}