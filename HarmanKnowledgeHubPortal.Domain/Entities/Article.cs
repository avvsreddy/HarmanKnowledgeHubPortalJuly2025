using HarmanKnowledgeHubPortal.Domain.Entities;

public class Article
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public string PostedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    //public DateTime DateSubmitted { get; set; }

    public ICollection<ArticleTag> ArticleTags { get; set; } = new List<ArticleTag>();
    public ArticleStatus Status { get; set; } // enum Pending/Approved/Rejected
    //public object RatingsAndReviews { get; set; }
    public ICollection<RatingAndReview> RatingsAndReviews { get; set; } = new List<RatingAndReview>();

}
