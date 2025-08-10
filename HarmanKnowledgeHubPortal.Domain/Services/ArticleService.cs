using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task ReviewArticlesAsync(ReviewArticleDto dto)
        {
            var action = dto.Action.ToLower();

            if (action == "approve")
            {
                await _articleRepo.ApproveAsync(dto.ArticleIds);
                await _notificationService.SendEmailAsync(
                    "publisher@example.com",
                    "Article Approved",
                    "Your article has been approved."
                );
            }
            else if (action == "reject")
            {
                await _articleRepo.RejectAsync(dto.ArticleIds);
                await _notificationService.SendEmailAsync(
                    "publisher@example.com",
                    "Article Rejected",
                    "Your article has been rejected."
                );
            }
            else
            {
                throw new Exception("Invalid action. Only 'Approve' or 'Reject' are allowed.");
            }
        }

        public async Task<List<ReviewArticleDto>> GetPendingArticlesAsync(int categoryId)
        {
            var articles = await _articleRepo.ReviewAsync(categoryId);

            foreach (var article in articles)
            {
                await _notificationService.SendEmailAsync(
                    "publisher@example.com",
                    "Article Pending Review",
                    $"Your article '{article.Title}' is pending review."
                );
            }

            return articles.Select(article => new ReviewArticleDto
            {
                ArticleIds = new List<int> { article.Id },
                Action = "Pending"
            }).ToList();
        }

        public async Task SubmitArticleAsync(int articleId)
        {
            await _notificationService.SendEmailAsync(
                "publisher@example.com",
                "Article Submitted",
                "Your article has been submitted successfully."
            );
        }
    }
}