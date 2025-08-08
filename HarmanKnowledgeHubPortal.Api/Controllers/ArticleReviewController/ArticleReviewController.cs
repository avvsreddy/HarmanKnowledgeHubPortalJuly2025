using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HarmanKnowledgeHubPortal.Api.Controllers.ArticleReviewController
{

        [ApiController]
        [Route("api/[controller]")]
        public class ArticleReviewController : ControllerBase
        {
            private readonly IArticleService _articleService;

        public ArticleReviewController(IArticleService articleService, ISubmittedUrlService submittedUrlService)
        {
            _articleService = articleService;
            _submittedUrlService = submittedUrlService;
        }

            /// <summary>
            /// Approve or reject articles (Admin only)
            /// </summary>
            /// <param name="dto">Review details including article IDs and action</param>
            /// <returns>Success or error message</returns>
            [HttpPost("review")]
            [ProducesResponseType(typeof(object), 200)]
            [ProducesResponseType(typeof(object), 400)]
            public async Task<IActionResult> ReviewArticlesAsync([FromBody] ReviewArticleDto dto)
            {
                try
                {
                    await _articleService.ReviewArticlesAsync(dto);
                    return Ok(new { message = $"Articles {dto.Action.ToLower()}ed successfully." });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }

            /// <summary>
            /// Get all pending articles for a category (Admin only)
            /// </summary>
            /// <param name="categoryId">The ID of the category</param>
            /// <returns>List of pending articles</returns>
            [HttpGet("pending")]
            [ProducesResponseType(typeof(List<ReviewArticleDto>), 200)]
            public async Task<IActionResult> GetPendingArticlesAsync([FromQuery] int categoryId)
            {
                var articles = await _articleService.GetPendingArticlesAsync(categoryId);
                return Ok(articles);
            }
        }
    }

