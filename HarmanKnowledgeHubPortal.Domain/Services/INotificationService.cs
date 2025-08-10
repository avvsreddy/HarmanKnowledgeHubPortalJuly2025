using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public interface INotificationService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}