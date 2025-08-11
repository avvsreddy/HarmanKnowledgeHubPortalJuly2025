using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateCategoryAsync(CategoryCreateDTO dto)
        {
            var category = new Category
            {
                CategoryName = dto.CategoryName,
                CategoryDescription = dto.CategoryDescription,
                DateTimeCreate = System.DateTime.UtcNow,
                IsDeleted = false
            };

            await _categoryRepository.CreateAsync(category);
        }

        public async Task<List<CategoryListDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return categories.Select(c => new CategoryListDTO
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
                CategoryDescription = c.CategoryDescription,
                //DateTimeCreate = c.DateTimeCreate
            }).ToList();
        }

        public async Task<CategoryListDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null || category.IsDeleted)
                return null;

            return new CategoryListDTO
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
                //DateTimeCreate = category.DateTimeCreate
            };
        }

        public async Task UpdateCategoryAsync(int id, CategoryCreateDTO dto)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category != null && !category.IsDeleted)
            {
                category.CategoryName = dto.CategoryName;
                category.CategoryDescription = dto.CategoryDescription;
                await _categoryRepository.UpdateAsync(category);
            }
        }

        public async Task SoftDeleteCategoryAsync(int id)
        {
            await _categoryRepository.SoftDeleteAsync(id);
        }
    }
}
