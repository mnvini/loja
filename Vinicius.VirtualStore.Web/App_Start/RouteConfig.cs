using System.Web.Mvc;
using System.Web.Routing;

namespace Vinicius.VirtualStore.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //1 - Start
            routes.MapRoute(
                 null,
                 "",
                 new { controller = "Showcase", 
                     action = "ProductsList", 
                     category = (string)null , page = 1 }
            );
            //2
            routes.MapRoute(
                 null,
                 "page{page}",
                 new { controller = "Showcase", action = "ProductsList", category = (string)null }, new { page = @"\d+" }
            );

           //3
            routes.MapRoute(
                null,
                "{category}",
                new { controller = "Showcase", action = "ProductsList", page=1 }
            );

            //4
            routes.MapRoute(
                 null,
                 "{category}/page{page}",
                 new { controller = "Showcase", action = "ProductsList" }, new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
