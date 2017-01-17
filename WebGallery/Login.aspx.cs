using Ninject;
using Repository.DAL.Interfaces;
using Repository.POCO;
using System;
using System.Web;
using System.Web.UI;
using WebGallery.ViewModel;

namespace WebGallery
{
    public partial class Login : Page
    {
        [Inject]
        public IUnitOfWork Database { get; set; }


        public void LoginUser(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                OperationResult result = Database.Users.LoginUser(model.UserName, model.Password, HttpContext.Current.GetOwinContext().Authentication);

                if (result.Succeded)
                {
                    if (Request.QueryString["ReturnUrl"] != null)
                        Response.Redirect(Request.QueryString["ReturnUrl"]);

                    Response.Redirect("~/галлерея/1");
                }
                else
                    ModelState.AddModelError("error", result.Message);
                

            }
        }



    }
}