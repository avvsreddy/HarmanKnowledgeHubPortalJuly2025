using HarmanKnowledgeHubPortal.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _dashboardService;

        public DashboardController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboardStats()
        {
            var reports = await _dashboardService.GetReportsAsync(0, null, null, null); // pass actual values if needed

            var totalArticles = reports.Sum(r => r.TotalArticles);

            var currentMonth = DateTime.UtcNow.Month;
            var currentYear = DateTime.UtcNow.Year;

            var articlesThisMonth = reports
                .Where(r => r.CreatedOn.Month == currentMonth && r.CreatedOn.Year == currentYear)
                .Sum(r => r.TotalArticles);

            var articlesApproved = reports.Sum(r => r.ArticlesApproved);
            var articlesRejected = reports.Sum(r => r.ArticlesRejected);
            var articlesPending = reports.Sum(r => r.ArticlesPending);

            var totalReviews = reports.Sum(r => r.TotalReviews);
            var totalRatings = reports.Sum(r => r.TotalRatings);

            var topPublisher = reports
                .Where(r => r.CreatedOn.Month == currentMonth && r.CreatedOn.Year == currentYear)
                .GroupBy(r => r.UserId)
                .Select(g => new {
                    UserId = g.Key,
                    Articles = g.Sum(r => r.TotalArticles)
                })
                .OrderByDescending(g => g.Articles)
                .FirstOrDefault();

            var dashboardDto = new
            {
                TotalArticles = totalArticles,
                ArticlesAddedThisMonth = articlesThisMonth,
                ArticlesApproved = articlesApproved,
                ArticlesRejected = articlesRejected,
                ArticlesPending = articlesPending,
                TotalReviews = totalReviews,
                TotalRatings = totalRatings,
                TopPublisherThisMonth = topPublisher
            };

            return Ok(dashboardDto);
        }
    }
}
