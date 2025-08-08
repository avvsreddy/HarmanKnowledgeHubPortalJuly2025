using System;

namespace HarmanKnowledgeHubPortal.Domain.DTO
{
    public class DashboardDto
    {
        public int TotalArticles { get; set; }
        public int ArticlesApproved { get; set; }
        public int ArticlesRejected { get; set; }
        public int ArticlesPending { get; set; }
        public int TotalReviews { get; set; }
        public int TotalRatings { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class ReportDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}