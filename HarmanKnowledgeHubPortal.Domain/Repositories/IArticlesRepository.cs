using HarmanKnowledgeHubPortal.Domain.Entities;

namespace HarmanKnowledgeHubPortal.Domain.Repositories
{
    public interface IArticlesRepository
    {
        void Submit(Article article);
        void Update(Article article);
        void Approve(List<int> articleIds);
        void Reject(List<int> articleIds);
        List<Article> Browse(int categoryId, string tag);
        List<Article> Review(int categoryId);
    }
}
