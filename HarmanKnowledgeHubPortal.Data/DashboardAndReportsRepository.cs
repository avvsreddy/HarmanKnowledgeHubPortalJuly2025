using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Data
{
    public class DashboardAndReportsRepository : IDashboardAndReportsRepository
    {
        private readonly AppDbContext _context;

        public DashboardAndReportsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Report> GetDashboardByUserIdAsync(int userId)
        {
            var articles = await _context.Articles
                .Include(a => a.RatingsAndReviews)
                .Where(a => a.SubmittedBy == userId.ToString())
                .ToListAsync();

            return new Report
            {
                UserId = userId,
                TotalArticles = articles.Count,
                ArticlesApproved = articles.Count(a => a.Status == ArticleStatus.APPROVED),
                ArticlesRejected = articles.Count(a => a.Status == ArticleStatus.REJECTED),
                ArticlesPending = articles.Count(a => a.Status == ArticleStatus.PENDING),
                TotalReviews = articles.Sum(a => a.RatingsAndReviews.Count),
                TotalRatings = articles.Sum(a => a.RatingsAndReviews.Count(r => r.RatingNumber > 0)),
                CreatedOn = DateTime.UtcNow
            };
        }

        public async Task<List<Report>> GetReportsAsync(int userId, DateTime? startDate, DateTime? endDate, string category)
        {
            var query = _context.Set<Report>()
                .Where(r => r.UserId == userId && !r.IsDeleted);

            if (startDate.HasValue)
                query = query.Where(r => r.CreatedOn >= startDate);
            if (endDate.HasValue)
                query = query.Where(r => r.CreatedOn <= endDate);

            return await query.ToListAsync();
        }

        public async Task CreateReportAsync(Report report)
        {
            await _context.Set<Report>().AddAsync(report);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReportAsync(Report report)
        {
            _context.Set<Report>().Update(report);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteReportAsync(int id)
        {
            var report = await _context.Set<Report>().FindAsync(id);
            if (report != null)
            {
                report.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
