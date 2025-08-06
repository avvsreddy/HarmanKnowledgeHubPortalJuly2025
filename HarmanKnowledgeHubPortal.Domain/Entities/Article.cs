namespace HarmanKnowledgeHubPortal.Domain.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? URL { get; set; }
        public string? Description { get; set; }

        public ArticleStatus Status { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public List<ArticleTag> ArticleTags { get; set; } = new();
        public List<Rating> RatingsAndReviews { get; set; } = new();

        public string? SubmittedBy { get; set; }
        public DateTime DateSubmitted { get; set; }
    }
}
