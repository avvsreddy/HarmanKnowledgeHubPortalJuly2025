using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public interface INotifications
    {
        Task SendNotificationAsync(string toEmail, string subject, string message);
    }
}
