using System.Web.Mvc;
using System.Web.Routing;

namespace IdentitySample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Login",
            url: "admin",
            defaults: new { controller = "Account", action = "Login" });

            routes.MapRoute(
                name: "MobileApp",
                url: "qu",
                defaults: new { controller = "MobileApp", action = "Index" });

                routes.MapRoute(
                    name: "Edit",
                    url: "qu/edit/{id}",
                    defaults: new { controller = "MobileApp", action = "NewQuestion", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Register", id = UrlParameter.Optional }
            );

        }
    }
}