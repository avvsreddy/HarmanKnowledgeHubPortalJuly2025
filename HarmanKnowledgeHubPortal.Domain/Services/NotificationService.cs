using HarmanKnowledgeHubPortal.Domain.Services;

using System.Net;
using System.Net.Mail;

namespace HarmanKnowledgeHubPortal.Domain.Services;

public class NotificationService : INotifications
{
    public async Task SendNotificationAsync(string toEmail, string subject, string message)
    {
        var fromEmail = "your-email@example.com";
        var smtpHost = "smtp.gmail.com";
        var smtpPort = 587;
        var emailPassword = "your-app-password"; // Use app password for Gmail

        var mail = new MailMessage(fromEmail, toEmail, subject, message);
        var smtpClient = new SmtpClient(smtpHost)
        {
            Port = smtpPort,
            Credentials = new NetworkCredential(fromEmail, emailPassword),
            EnableSsl = true
        };

        await smtpClient.SendMailAsync(mail);
    }
}
