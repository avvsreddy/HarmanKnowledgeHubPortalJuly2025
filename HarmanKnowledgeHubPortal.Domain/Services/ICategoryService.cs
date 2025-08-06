using HarmanKnowledgeHubPortal.Domain.DTO;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public interface ICategoryService
    {
        void CreateCategory(CategoryCreateDTO categoryCreateDTO);

        // similarly add required methods in async format

    }
}
