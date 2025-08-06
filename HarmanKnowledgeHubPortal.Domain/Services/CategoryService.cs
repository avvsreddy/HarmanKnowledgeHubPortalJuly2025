using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Repositories;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public void CreateCategory(CategoryCreateDTO categoryCreateDTO)
        {
            // convert DTO into Entities
            Category category = new Category();
            category.CategoryName = categoryCreateDTO.CategoryName;
            category.CategoryDescription = categoryCreateDTO.CategoryDescription;

            category.DateTimeCreate = DateTime.Now;
            category.IsDeleted = false;

            // call DAL methods
            _categoryRepository.Create(category);
        }
    }
}
