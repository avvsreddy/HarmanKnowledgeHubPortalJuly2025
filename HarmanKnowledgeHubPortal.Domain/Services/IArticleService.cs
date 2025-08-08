using HarmanKnowledgeHubPortal.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public interface IArticleService
    {
        Task<List<ReviewArticleDto>> GetPendingArticlesAsync(int categoryId);
        // Approve or Reject
        Task ReviewArticlesAsync(ReviewArticleDto dto);
    }
}

