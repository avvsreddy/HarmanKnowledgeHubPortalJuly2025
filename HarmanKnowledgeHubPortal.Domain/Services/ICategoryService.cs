using HarmanKnowledgeHubPortal.Domain.DTO;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public interface ICategoryService
    {
        Task CreateCategoryAsync(CategoryCreateDTO dto);
        Task<List<CategoryListDTO>> GetAllCategoriesAsync();
        Task<CategoryListDTO> GetCategoryByIdAsync(int id);
        Task UpdateCategoryAsync(int id, CategoryCreateDTO dto);
        Task SoftDeleteCategoryAsync(int id);
    }
}