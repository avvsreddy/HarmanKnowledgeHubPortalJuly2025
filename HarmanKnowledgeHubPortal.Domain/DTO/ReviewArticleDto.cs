// Request DTO - from client to API
public class ApproveUrlsRequestDto
{
    public string Category { get; set; } // selected category from dropdown
}

// Response DTO - from API to client
public class ApproveUrlsResponseDto
{
    public bool Select { get; set; }  // checkbox status
    public string Title { get; set; } // title of the URL
    public string Url { get; set; }   // actual URL
    public string Category { get; set; } // category name
}

// Approve/Reject action request DTO
public class ApproveRejectActionRequestDto
{
    public List<int> UrlIds { get; set; } // IDs of selected URLs
    public string Action { get; set; }    // "Approve" or "Reject"
}

// Approve/Reject action response DTO
public class ApproveRejectActionResponseDto
{
    public int StatusCode { get; set; }   // HTTP status code
    public string Message { get; set; }   // optional confirmation message
}
