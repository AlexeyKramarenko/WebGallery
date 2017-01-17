using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebGallery.App_Start;

namespace WebGallery
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            AutoMapperConfig.RegisterMappings();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

   
    }
}