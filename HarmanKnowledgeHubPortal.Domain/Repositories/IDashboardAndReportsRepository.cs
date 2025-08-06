using HarmanKnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Repositories
{
    public interface IDashboardAndReportsRepository
    {
        Task<Report> GetDashboardByUserIdAsync(int userId);
        Task<List<Report>> GetReportsAsync(int userId, DateTime? startDate, DateTime? endDate, string category);
        Task CreateReportAsync(Report report);
        Task UpdateReportAsync(Report report);
        Task SoftDeleteReportAsync(int id);
    }
}
