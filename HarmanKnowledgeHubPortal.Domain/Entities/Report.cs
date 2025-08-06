using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int TotalArticles { get; set; }
        public int ArticlesApproved { get; set; }
        public int ArticlesRejected { get; set; }
        public int ArticlesPending { get; set; }
        public int TotalReviews { get; set; }
        public int TotalRatings { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}

