using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmanKnowledgeHubPortal.Domain.DTO;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public class DashboardService
    {
        private readonly IDashboardAndReportsRepository _dashboardRepo;

        public DashboardService(IDashboardAndReportsRepository dashboardRepo)
        {
            _dashboardRepo = dashboardRepo;
        }

        public async Task<DashboardDto> GetDashboardAsync(int userId)
        {
            var report = await _dashboardRepo.GetDashboardByUserIdAsync(userId);

            if (report == null) return null;

            return new DashboardDto
            {
                TotalArticles = report.TotalArticles,
                ArticlesApproved = report.ArticlesApproved,
                ArticlesRejected = report.ArticlesRejected,
                ArticlesPending = report.ArticlesPending,
                TotalReviews = report.TotalReviews,
                TotalRatings = report.TotalRatings,
                CreatedOn = report.CreatedOn
            };
        }

        public async Task<List<Report>> GetReportsAsync(int userId, DateTime? startDate, DateTime? endDate, string category)
        {
            return await _dashboardRepo.GetReportsAsync(userId, startDate, endDate, category);
        }

        public async Task CreateReportAsync(Report report)
        {
            await _dashboardRepo.CreateReportAsync(report);
        }

        public async Task UpdateReportAsync(Report report)
        {
            await _dashboardRepo.UpdateReportAsync(report);
        }

        public async Task SoftDeleteReportAsync(int id)
        {
            await _dashboardRepo.SoftDeleteReportAsync(id);
        }
    }
}