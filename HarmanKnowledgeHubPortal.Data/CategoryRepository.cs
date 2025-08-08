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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Category category)
        {
            category.DateTimeCreate = DateTime.UtcNow;
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _context.Categories
                .Where(c => !c.IsDeleted)
                .OrderByDescending(c => c.DateTimeCreate)
                .ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories
                .FirstOrDefault(c => c.Id == id && !c.IsDeleted);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void SoftDelete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null && !category.IsDeleted)
            {
                category.IsDeleted = true;
                _context.SaveChanges();
            }
        }
    }
}
