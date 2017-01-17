using Ninject;
using Repository.DAL.Interfaces;
using System;
using System.Web;

namespace WebGallery.Admin
{
    public partial class NestedAdminMasterPage : System.Web.UI.MasterPage
    { 
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!Request.IsAuthenticated)
                Response.Redirect("/Login.aspx?ReturnURL=" + HttpContext.Current.Request.Url.AbsoluteUri);

            else if (!HttpContext.Current.User.IsInRole("admin"))
                Response.Redirect("/404.aspx");

        }
    }
}