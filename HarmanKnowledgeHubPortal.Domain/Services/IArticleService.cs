using HarmanKnowledgeHubPortal.Domain.DTO;


using System.Collections.Generic;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public interface IArticleService
    {
        Task<List<ReviewArticleDto>> GetPendingArticlesAsync(int categoryId);
        Task ReviewArticlesAsync(ReviewArticleDto dto);
        Task SubmitArticleAsync(int articleId);
    }
}