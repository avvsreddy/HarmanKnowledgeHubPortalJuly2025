using HarmanKnowledgeHubPortal.Domain.DTO;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public interface IArticleService
    {
        
        void ReviewArticles(ReviewArticleDto dto); // Approve or Reject
    }
}
