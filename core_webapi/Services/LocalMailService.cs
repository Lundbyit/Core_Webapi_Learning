using System.Diagnostics;

namespace core_webapi.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailTo = Startup.Configuration["mailSettings:mailToAddress"];
        private string _mailFrom = "dummy@from.se";

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, LocalMailService");
            Debug.WriteLine($"Subject: {subject} test");
            Debug.WriteLine($"Message: {message}");
        }
    }
}
