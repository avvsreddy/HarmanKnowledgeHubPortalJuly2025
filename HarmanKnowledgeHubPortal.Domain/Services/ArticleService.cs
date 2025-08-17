using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using System;
using System.Collections.Generic;


using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticlesRepository _articleRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly INotificationService _notificationService;

        public ArticleService(
            IArticlesRepository articleRepo,
            ICategoryRepository categoryRepo,
            INotificationService notificationService)
        {
            _articleRepo = articleRepo;
            _categoryRepo = categoryRepo;
            _notificationService = notificationService;
        }

        // 1️⃣ Get pending URLs for selected category
        public async Task<List<ApproveUrlsResponseDto>> GetPendingApprovalsAsync(ApproveUrlsRequestDto request)
        {
            // Get category by name
            var category = await _categoryRepo.GetByNameAsync(request.Category);
            if (category == null)
                return new List<ApproveUrlsResponseDto>();

            // Get pending articles from repo
            var articles = await _articleRepo.ReviewAsync(category.Id);

            return articles.Select(article => new ApproveUrlsResponseDto
            {
                Select = false, // default unchecked
                Title = article.Title,
                Url = article.Url,
                Category = category.CategoryName
            }).ToList();
        }

        // 2️⃣ Approve selected URLs
        public async Task<ApproveRejectActionResponseDto> ApproveUrlsAsync(ApproveRejectActionRequestDto request)
        {
            await _articleRepo.ApproveAsync(request.UrlIds);

            // Send notifications
            foreach (var id in request.UrlIds)
            {
                await _notificationService.SendEmailAsync(
                    "publisher@example.com",
                    "Article Approved",
                    $"Your article (ID: {id}) has been approved."
                );
            }

            return new ApproveRejectActionResponseDto
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Selected URLs approved successfully."
            };
        }

        // 3️⃣ Reject selected URLs
        public async Task<ApproveRejectActionResponseDto> RejectUrlsAsync(ApproveRejectActionRequestDto request)
        {
            await _articleRepo.RejectAsync(request.UrlIds);

            // Send notifications
            foreach (var id in request.UrlIds)
            {
                await _notificationService.SendEmailAsync(
                    "publisher@example.com",
                    "Article Rejected",
                    $"Your article (ID: {id}) has been rejected."
                );
            }

            return new ApproveRejectActionResponseDto
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Selected URLs rejected successfully."
            };
        }
    }
}
