using HarmanKnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Repositories
{
    public interface ISubmittedUrlRepository
    {
        Task AddAsync(SubmittedUrl url);
        Task<IEnumerable<SubmittedUrl>> GetAllApprovedAsync();
    }
}
