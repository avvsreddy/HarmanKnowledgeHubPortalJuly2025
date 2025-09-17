using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Data
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AppDbContext _context;

        public DashboardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardDto> GetDashboardAsync()
        {
            var articles = await _context.Articles
                .Include(a => a.Category)
                .Include(a => a.RatingsAndReviews)
                .ToListAsync();

            var currentMonth = DateTime.UtcNow.Month;
            var currentYear = DateTime.UtcNow.Year;

            return new DashboardDto
            {
                ApprovedArticles = articles.Count(a => a.Status == ArticleStatus.APPROVED),
                RejectedArticles = articles.Count(a => a.Status == ArticleStatus.REJECTED),
                PendingArticles = articles.Count(a => a.Status == ArticleStatus.PENDING),
                ReviewedArticles = articles.Count(a => a.RatingsAndReviews.Any()),
                RatedArticles = articles.Count(a => a.RatingsAndReviews.Any(r => r.RatingNumber > 0)),

                ArticlesByCategory = articles
                    .GroupBy(a => a.Category.CategoryName)
                    .ToDictionary(g => g.Key, g => g.Count()),

                ArticlesByYear = articles
                    //.GroupBy(a => a.DateSubmitted.Year)
                    //.ToDictionary(g => g.Key, g => g.Count()),
                    .GroupBy(a => a.CreatedAt.Year)  // ✅ replace with your actual property
                    .ToDictionary(g => g.Key, g => g.Count()),

                ArticlesAddedThisMonth = articles
                    .Where(a => a.CreatedAt.Month == currentMonth && a.CreatedAt.Year == currentYear)
                    .GroupBy(a => a.CreatedAt.Day)
                    .OrderBy(g => g.Key)
                    .ToDictionary(g => g.Key, g => g.Count()),

                TopPublishersThisMonth = articles
                    .Where(a => a.CreatedAt.Month == currentMonth && a.CreatedAt.Year == currentYear)
                    .GroupBy(a => a.PostedBy)
                    .Select(g => new TopPublisherDto
                    {
                        PublisherName = g.Key,
                        ArticlesCount = g.Count(),
                        RatingsCount = g.SelectMany(a => a.RatingsAndReviews).Count()
                    })
                    .OrderByDescending(p => p.ArticlesCount)
                    .Take(3)
                    .ToList()
            };
        }
    }
}