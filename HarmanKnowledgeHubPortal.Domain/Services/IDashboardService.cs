using HarmanKnowledgeHubPortal.Domain.DTO;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardAsync();
    }
}