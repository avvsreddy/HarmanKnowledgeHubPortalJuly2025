using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public class DashboardService
    {
        private readonly IDashboardAndReportsRepository _dashboardRepo;

        public DashboardService(IDashboardAndReportsRepository dashboardRepo)
        {
            _dashboardRepo = dashboardRepo;
        }

        public Report GetDashboard(int userId)
        {
            return _dashboardRepo.GetDashboardByUserId(userId);
        }

        public List<Report> GetReports(int userId, DateTime? start, DateTime? end, string category)
        {
            return _dashboardRepo.GetReports(userId, start, end, category);
        }
    }
}
