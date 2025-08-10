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

        public Dictionary<string, int> ArticlesByCategory { get; set; } = new();
        public Dictionary<int, int> ArticlesByYear { get; set; } = new();
        public Dictionary<int, int> ArticlesAddedThisMonth { get; set; } = new();
        public List<TopPublisherDto> TopPublishersThisMonth { get; set; } = new();
    }

    public class TopPublisherDto
    {
        public string PublisherName { get; set; } = string.Empty;
        public int ArticlesCount { get; set; }
        public int RatingsCount { get; set; }
    }
}
