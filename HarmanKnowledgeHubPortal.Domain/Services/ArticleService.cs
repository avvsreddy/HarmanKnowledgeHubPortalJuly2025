using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
        public class ArticleService : IArticleService
        {
            private readonly IArticlesRepository _articleRepo;
            private readonly ICategoryRepository _categoryRepo;

        public ArticleService(IArticlesRepository articleRepo, ICategoryRepository categoryRepo)
        {
            _articleRepo = articleRepo;
            _categoryRepo = categoryRepo;
        }

            public async Task ReviewArticlesAsync(ReviewArticleDto dto)
            {
                var action = dto.Action.ToLower();

                if (action == "approve")
                {
                    await _articleRepo.ApproveAsync(dto.ArticleIds);
                }
                else if (action == "reject")
                {
                    await _articleRepo.RejectAsync(dto.ArticleIds);
                }
                else
                {
                    throw new Exception("Invalid action. Only 'Approve' or 'Reject' are allowed.");
                }
            }

            public async Task<List<ReviewArticleDto>> GetPendingArticlesAsync(int categoryId)
            {
                var articles = await _articleRepo.ReviewAsync(categoryId);

                return articles.Select(article => new ReviewArticleDto
                {
                    ArticleIds = new List<int> { article.Id },
                    Action = "Pending"
                }).ToList();
            }
        }
    }

