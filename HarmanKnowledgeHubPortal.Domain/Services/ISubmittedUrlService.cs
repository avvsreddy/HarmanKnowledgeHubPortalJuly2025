using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public interface ISubmittedUrlService
    {
        Task<SubmittedUrl> SubmitUrlAsync(SubmitUrlDTO dto);
        Task<IEnumerable<SubmittedUrl>> GetApprovedUrlsAsync();
    }
}
