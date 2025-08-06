using HarmanKnowledgeHubPortal.Domain.DTO;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public interface ICategoryService
    {
        void CreateCategory(CategoryCreateDTO categoryCreateDTO);

        // similarly add required methods in async format
        List<CategoryCreateDTO> GetAllCategories();
        CategoryCreateDTO GetCategoryById(int id);
        void UpdateCategory(int id, CategoryCreateDTO categoryCreateDTO);
        void SoftDeleteCategory(int id);

    }
}