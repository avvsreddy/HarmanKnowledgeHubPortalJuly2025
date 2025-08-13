using HarmanKnowledgeHubPortal.Domain.DTO;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Repositories
{
    public interface IDashboardRepository
    {
        Task<DashboardDto> GetDashboardAsync();
    }
}