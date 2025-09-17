namespace HarmanKnowledgeHubPortal.Domain.Entities
{
    public class RatingAndReview
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        // ✅ numeric rating (e.g., 1–5 stars)
        public int RatingNumber { get; set; }

        // ✅ optional review text
        public string ReviewText { get; set; } = string.Empty;

        // ✅ who gave the rating
        public string RatedBy { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
