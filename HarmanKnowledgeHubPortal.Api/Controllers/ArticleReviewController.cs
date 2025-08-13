using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HarmanKnowledgeHubPortal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleReviewController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly ISubmittedUrlService _submittedUrlService;

        public ArticleReviewController(IArticleService articleService, ISubmittedUrlService submittedUrlService)
        {
            _articleService = articleService;
            _submittedUrlService = submittedUrlService;
        }

        /// <summary>
        /// Approve selected articles (Admin only)
        /// </summary>
        [HttpPost("approve")]
        [ProducesResponseType(typeof(ApproveRejectActionResponseDto), 200)]
        [ProducesResponseType(typeof(object), 400)]
        public async Task<IActionResult> ApproveUrlsAsync([FromBody] ApproveRejectActionRequestDto dto)
        {
            try
            {
                var result = await _articleService.ApproveUrlsAsync(dto);
                return StatusCode(result.StatusCode, new { message = result.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Reject selected articles (Admin only)
        /// </summary>
        [HttpPost("reject")]
        [ProducesResponseType(typeof(ApproveRejectActionResponseDto), 200)]
        [ProducesResponseType(typeof(object), 400)]
        public async Task<IActionResult> RejectUrlsAsync([FromBody] ApproveRejectActionRequestDto dto)
        {
            try
            {
                var result = await _articleService.RejectUrlsAsync(dto);
                return StatusCode(result.StatusCode, new { message = result.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get all pending articles for a category (Admin only)
        /// </summary>
        [HttpGet("pending")]
        [ProducesResponseType(typeof(List<ApproveUrlsResponseDto>), 200)]
        public async Task<IActionResult> GetPendingApprovalsAsync([FromQuery] string category)
        {
            var result = await _articleService.GetPendingApprovalsAsync(new ApproveUrlsRequestDto
            {
                Category = category
            });
            return Ok(result);
        }


        /// <summary>
        /// Submit a new article URL (User)
        /// </summary>
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitArticle([FromBody] SubmitUrlDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var submittedUrl = await _submittedUrlService.SubmitUrlAsync(dto);
                return CreatedAtAction(nameof(BrowseArticles), new { }, submittedUrl);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Browse all approved articles (Public/User)
        /// </summary>
        [HttpGet("browse")]
        public async Task<IActionResult> BrowseArticles()
        {
            try
            {
                var approvedUrls = await _submittedUrlService.GetApprovedUrlsAsync();

                var result = approvedUrls.Select(u => new BrowseUrlDTO
                {
                    Title = u.Title,
                    Url = u.Url,
                    Description = u.Description,
                    PostedBy = u.User?.Name ?? "Unknown",
                    CategoryName = u.Category?.CategoryName ?? "Uncategorized"
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}