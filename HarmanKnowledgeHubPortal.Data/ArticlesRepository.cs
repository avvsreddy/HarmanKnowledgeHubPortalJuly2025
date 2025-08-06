using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Data
{
        public class ArticlesRepository : IArticlesRepository
        {
            private readonly AppDbContext _context;

            public ArticlesRepository(AppDbContext context)
            {
                _context = context;
            }

            public void Submit(Article article)
            {
                article.Status = ArticleStatus.PENDING;
                article.DateSubmitted = DateTime.UtcNow;
                _context.Articles.Add(article);
                _context.SaveChanges();
            }

            public void Update(Article article)
            {
                _context.Articles.Update(article);
                _context.SaveChanges();
            }

            public void Approve(List<int> articleIds)
            {
                var articles = _context.Articles.Where(a => articleIds.Contains(a.Id)).ToList();
                foreach (var article in articles)
                    article.Status = ArticleStatus.APPROVED;

                _context.SaveChanges();
            }

            public void Reject(List<int> articleIds)
            {
                var articles = _context.Articles.Where(a => articleIds.Contains(a.Id)).ToList();
                foreach (var article in articles)
                    article.Status = ArticleStatus.REJECTED;

                _context.SaveChanges();
            }

            public List<Article> Browse(int categoryId, string tag)
            {
                return _context.Articles
                    .Include(a => a.Tags)
                    .Include(a => a.Category)
                    .Where(a => a.Status == ArticleStatus.APPROVED &&
                                a.Category.Id == categoryId &&
                                a.Tags.Any(t => t.TagName == tag))
                    .ToList();
            }

            public List<Article> Review(int categoryId)
            {
                return _context.Articles
                    .Include(a => a.Category)
                    .Where(a => a.Status == ArticleStatus.PENDING &&
                                a.Category.Id == categoryId)
                    .ToList();
            }
        }
    }

