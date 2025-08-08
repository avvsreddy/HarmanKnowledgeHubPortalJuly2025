using HarmanKnowledgeHubPortal.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Repositories
{
    public interface ISubmittedUrlRepository
    {
        Task AddAsync(SubmittedUrl url);
        Task<IEnumerable<SubmittedUrl>> GetAllApprovedAsync();
    }
}
