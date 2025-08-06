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
        [Required]
        public List<int> ArticleIds { get; set; }

        [Required]
        public string Action { get; set; } // "Approve" or "Reject"
    }
}
