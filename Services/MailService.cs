using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MailService : IMailService
    {
        string ADMIN = "legna51@mail.ru";

        public void SendMessage(string senderEmail, string subject, string senderName, string message)
        {
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderEmail);
            mailMessage.To.Add(ADMIN);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "<b>Вам пришло новое сообщение от посетителя Вашего сайта.<br/>Имя отправителя : </b>" + senderName + "<br/>"
                             + "<b>E-mail, указанный отправителем : </b>" + senderEmail + "<br/>"
                             + "<b>Тема : </b>" + subject
                             + "<b>Сообщение :</b><br/>" + message;
                        

            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("abrakadabra364@gmail.com", "hallucination");
            smtpClient.Send(mailMessage);
        }
    }
}
