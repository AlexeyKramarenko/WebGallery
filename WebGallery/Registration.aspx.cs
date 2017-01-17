using Ninject;
using Repository.DAL.Interfaces;
using Repository.POCO;
using System.Web;
using WebGallery.ViewModel;

namespace WebGallery
{
    public partial class Registration : System.Web.UI.Page
    {
        [Inject]
        public IUnitOfWork Database { get; set; }
      
       
        public void CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                OperationResult result = Database.Users.CreateUser(model.UserName, model.Password, HttpContext.Current.GetOwinContext().Authentication);

                if (result.Succeded)
                {
                    Response.Redirect("~/галлерея/1");
                }

                litStatusMessage.Text = result.Message;
            }
            
        }


    }
}