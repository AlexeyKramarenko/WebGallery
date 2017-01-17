using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace WebGallery.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");

            routes.MapPageRoute("gallery", routeUrl: "галлерея/{galleryId}", physicalFile: "~/Gallery.aspx");
            routes.MapPageRoute("contacts", routeUrl: "контакты", physicalFile: "~/Contacts.aspx");
            routes.MapPageRoute("intro", routeUrl: "", physicalFile: "~/Gallery.aspx");

            routes.MapPageRoute("login", routeUrl: "логин", physicalFile: "~/Login.aspx");
            routes.MapPageRoute(null, routeUrl: "контакты/логин", physicalFile: "~/Login.aspx");
            routes.MapPageRoute(null, routeUrl: "книги/логин", physicalFile: "~/Login.aspx");
            routes.MapPageRoute(null, routeUrl: "тортики/логин", physicalFile: "~/Login.aspx");
            routes.MapPageRoute(null, routeUrl: "проза/логин", physicalFile: "~/Login.aspx");

            routes.MapPageRoute("admin", routeUrl: "админ", physicalFile: "~/Admin/AddImage.aspx");
            routes.MapPageRoute(null, routeUrl: "контакты/админ", physicalFile: "~/Admin/AddImage.aspx");
            routes.MapPageRoute(null, routeUrl: "книги/админ", physicalFile: "~/Admin/AddImage.aspx");
            routes.MapPageRoute(null, routeUrl: "тортики/админ", physicalFile: "~/Admin/AddImage.aspx");
            routes.MapPageRoute(null, routeUrl: "проза/админ", physicalFile: "~/Admin/AddImage.aspx");

            for (int i = 1; i < 10; i++)
            {
                routes.MapPageRoute(null, routeUrl: "галлерея/" + i + "/логин", physicalFile: "~/Login.aspx");
                routes.MapPageRoute(null, routeUrl: "галлерея/" + i + "/админ", physicalFile: "~/Admin/AddImage.aspx");                
            }

        }
    }
}
