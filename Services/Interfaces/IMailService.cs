namespace Services.Interfaces
{
    public interface IMailService
    {
        void SendMessage(string senderEmail, string subject, string senderName, string message);
    }
}