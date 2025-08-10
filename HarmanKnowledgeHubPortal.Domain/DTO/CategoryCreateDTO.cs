using System.ComponentModel.DataAnnotations;

namespace HarmanKnowledgeHubPortal.Domain.DTO
{
    public class CategoryCreateDTO
    {
        [MaxLength(50)]
        [MinLength(3)]
        public string CategoryName { get; set; }
        [MaxLength(500)]
        [MinLength(5)]
        public string CategoryDescription { get; set; }
    }
}
