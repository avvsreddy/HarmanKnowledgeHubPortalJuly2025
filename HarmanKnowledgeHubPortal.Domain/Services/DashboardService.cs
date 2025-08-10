using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly INotificationService _notificationService;

        public DashboardService(IDashboardRepository dashboardRepository, INotificationService notificationService)
        {
            _dashboardRepository = dashboardRepository;
            _notificationService = notificationService;
        }

        public async Task<DashboardDto> GetDashboardAsync()
        {
            var dashboard = await _dashboardRepository.GetDashboardAsync();

            if (dashboard.TopPublishersThisMonth.Any())
            {
                var topPublisher = dashboard.TopPublishersThisMonth.First();
                await _notificationService.SendEmailAsync(
                    "publisher@example.com",
                    "Top Publisher Award",
                    $"Congratulations {topPublisher.PublisherName}! You are the top publisher this month with {topPublisher.ArticlesCount} articles."
                );
            }

            return dashboard;
        }
    }
}