using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HarmanKnowledgeHubPortal.Data.Repositories
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticlesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Submit(Article article)
        {
            article.Status = ArticleStatus.PENDING;
            article.DateSubmitted = DateTime.Now;
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public void Update(Article article)
        {
            _context.Articles.Update(article);
            _context.SaveChanges();
        }

        public void Approve(List<int> articleIds)
        {
            var articles = _context.Articles.Where(a => articleIds.Contains(a.Id)).ToList();
            foreach (var article in articles)
            {
                article.Status = ArticleStatus.APPROVED;
            }
            _context.SaveChanges();
        }

        public void Reject(List<int> articleIds)
        {
            var articles = _context.Articles.Where(a => articleIds.Contains(a.Id)).ToList();
            foreach (var article in articles)
            {
                article.Status = ArticleStatus.REJECTED;
            }
            _context.SaveChanges();
        }

        public List<Article> Browse(int categoryId, string tag)
        {
            var query = _context.Articles
                .Include(a => a.Category)
                .Include(a => a.ArticleTags).ThenInclude(at => at.Tag)
                .Where(a => a.Status == ArticleStatus.APPROVED);

            if (categoryId > 0)
                query = query.Where(a => a.CategoryId == categoryId);

            if (!string.IsNullOrWhiteSpace(tag))
                query = query.Where(a => a.ArticleTags.Any(at => at.Tag.TagName == tag));

            return query.ToList();
        }

        public List<Article> Review(int categoryId)
        {
            return _context.Articles
                .Where(a => a.Status == ArticleStatus.PENDING && a.CategoryId == categoryId)
                .ToList();
        }
    }
}
