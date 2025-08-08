using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.DTO
{
    public class ReviewArticleDto
    {
        [Required(ErrorMessage = "ArticleIds are required.")]
        [MinLength(1, ErrorMessage = "At least one article ID must be provided.")]
        public List<int> ArticleIds { get; set; } = new();

        [Required(ErrorMessage = "Action is required.")]
        [RegularExpression("Approve|Reject", ErrorMessage = "Action must be either 'Approve' or 'Reject'.")]
        public string Action { get; set; } = string.Empty; // Enforce specific allowed values
    }
}
