using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using HarmanKnowledgeHubPortal.Data;
using Microsoft.EntityFrameworkCore;


namespace HarmanKnowledgeHubPortal.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Category category)
        {
            category.DateTimeCreate = System.DateTime.UtcNow;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null && !category.IsDeleted)
            {
                category.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
