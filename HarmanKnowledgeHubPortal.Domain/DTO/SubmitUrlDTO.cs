public class SubmitUrlDTO
{
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty; // replace SubmittedUrl
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public int UserId { get; set; }
    public List<int> TagIds { get; set; } = new();
}
