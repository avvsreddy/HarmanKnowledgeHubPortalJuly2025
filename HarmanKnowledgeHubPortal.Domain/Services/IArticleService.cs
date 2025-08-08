using HarmanKnowledgeHubPortal.Domain.DTO;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public interface IArticleService
    {
        Task<List<ReviewArticleDto>> GetPendingArticlesAsync(int categoryId);
        // Approve or Reject
        Task ReviewArticlesAsync(ReviewArticleDto dto);
    }
}

