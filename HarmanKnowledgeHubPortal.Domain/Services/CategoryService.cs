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
            Category category = new Category
            {
                CategoryName = categoryCreateDTO.CategoryName,
                CategoryDescription = categoryCreateDTO.CategoryDescription,
                DateTimeCreate = DateTime.Now,
                IsDeleted = false
            };
            //call DAL methods
            _categoryRepository.Create(category);
        }

        public List<CategoryCreateDTO> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();

            return categories.Select(category => new CategoryCreateDTO
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
                DateTimeCreate = category.DateTimeCreate
            }).ToList();
        }

        public CategoryCreateDTO GetCategoryById(int id)
        {
            var category = _categoryRepository.GetById(id);

            if (category == null || category.IsDeleted)
                return null;

            return new CategoryCreateDTO
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
                DateTimeCreate = category.DateTimeCreate
            };
        }

        public void UpdateCategory(int id, CategoryCreateDTO categoryCreateDTO)
        {
            var category = _categoryRepository.GetById(id);

            if (category != null && !category.IsDeleted)
            {
                category.CategoryName = categoryCreateDTO.CategoryName;
                category.CategoryDescription = categoryCreateDTO.CategoryDescription;

                _categoryRepository.Update(category);
            }
        }

        public void SoftDeleteCategory(int id)
        {
            _categoryRepository.SoftDelete(id);
        }
    }
}
