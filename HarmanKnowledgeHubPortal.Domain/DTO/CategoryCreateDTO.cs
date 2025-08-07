using System.ComponentModel.DataAnnotations;

namespace HarmanKnowledgeHubPortal.Domain.DTO
{
    public class CategoryCreateDTO
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [MinLength(3)]
        public string CategoryName { get; set; }
        [MaxLength(500)]
        [MinLength(5)]
        public string CategoryDescription { get; set; }
        public DateTime DateTimeCreate { get; set; }
    }
}
