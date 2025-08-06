using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            public void ReviewArticles(ReviewArticleDto dto)
            {
                if (dto.Action.ToLower() == "approve")
                    _articleRepo.Approve(dto.ArticleIds);
                else if (dto.Action.ToLower() == "reject")
                    _articleRepo.Reject(dto.ArticleIds);
                else
                    throw new Exception("Invalid action");
            }
 
    }
}
