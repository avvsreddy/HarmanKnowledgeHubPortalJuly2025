using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HarmanKnowledgeHubPortal.Data
{
        public class ArticlesRepository : IArticlesRepository
        {
            private readonly AppDbContext _context;

            public ArticlesRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task SubmitAsync(Article article)
            {
                article.Status = ArticleStatus.PENDING;
                article.DateSubmitted = DateTime.UtcNow;
                await _context.Articles.AddAsync(article);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateAsync(Article article)
            {
                _context.Articles.Update(article);
                await _context.SaveChangesAsync();
            }

            public async Task ApproveAsync(List<int> articleIds)
            {
                var articles = await _context.Articles
                    .Where(a => articleIds.Contains(a.Id))
                    .ToListAsync();

                foreach (var article in articles)
                    article.Status = ArticleStatus.APPROVED;

                await _context.SaveChangesAsync();
            }

            public async Task RejectAsync(List<int> articleIds)
            {
                var articles = await _context.Articles
                    .Where(a => articleIds.Contains(a.Id))
                    .ToListAsync();

                foreach (var article in articles)
                    article.Status = ArticleStatus.REJECTED;

                await _context.SaveChangesAsync();
            }

            public async Task<List<Article>> BrowseAsync(int categoryId, string tag)
            {
                return await _context.Articles
                    .Include(a => a.Tags)
                    .Include(a => a.Category)
                    .Where(a => a.Status == ArticleStatus.APPROVED &&
                                a.Category.Id == categoryId &&
                                a.Tags.Any(t => t.TagName == tag))
                    .ToListAsync();
            }

            public async Task<List<Article>> ReviewAsync(int categoryId)
            {
                return await _context.Articles
                    .Include(a => a.Category)
                    .Where(a => a.Status == ArticleStatus.PENDING &&
                                a.Category.Id == categoryId)
                    .ToListAsync();
            }
        }
    }


