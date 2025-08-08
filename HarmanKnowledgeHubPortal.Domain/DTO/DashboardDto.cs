using System;
using System.Collections.Generic;

namespace HarmanKnowledgeHubPortal.Domain.DTO
{
    public class DashboardDto
    {
        public int ApprovedArticles { get; set; }
        public int RejectedArticles { get; set; }
        public int PendingArticles { get; set; }
        public int ReviewedArticles { get; set; }
        public int RatedArticles { get; set; }

        public Dictionary<string, int> ArticlesByCategory { get; set; }
        public Dictionary<int, int> ArticlesByYear { get; set; }
        public Dictionary<int, int> ArticlesAddedThisMonth { get; set; }

        public List<TopPublisherDto> TopPublishersThisMonth { get; set; }
    }

    public class TopPublisherDto
    {
        public string PublisherName { get; set; }
        public int ArticlesCount { get; set; }
        public int RatingsCount { get; set; }
    }
}
