using Ninject;
using Services.Interfaces;
using System;
using System.Web.UI;

namespace WebGallery
{
    public partial class Contacts : System.Web.UI.Page
    {
        [Inject]
        public IMailService MailService { get; set; }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    MailService.SendMessage(txtEmail.Text, txtSubject.Text, txtName.Text, txtComments.Text);

                    lblMessage.ForeColor = System.Drawing.Color.Blue;

                    lblMessage.Text = "Ваше сообщение отправлено!";

                    txtName.Enabled = false;
                    txtEmail.Enabled = false;
                    txtComments.Enabled = false;
                    txtSubject.Enabled = false;
                    Button1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = ex.Message;
            }
        }
    }
}