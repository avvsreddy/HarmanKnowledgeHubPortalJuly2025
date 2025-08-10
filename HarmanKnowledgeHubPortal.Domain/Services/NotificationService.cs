using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public class NotificationService : INotificationService
    {
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential("your-email@gmail.com", "your-app-password");
                smtp.EnableSsl = true;

                var message = new MailMessage("your-email@gmail.com", to, subject, body);
                await smtp.SendMailAsync(message);
            }
        }
    }
}