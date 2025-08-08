using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HarmanKnowledgeHubPortal.Api.Controllers.ArticleReviewController
{
        [ApiController]
        [Route("api/[controller]")]
        public class ArticleReviewController : ControllerBase
        {
            private readonly IArticleService _articleService;

            public ArticleReviewController(IArticleService articleService)
            {
                _articleService = articleService;
            }

            /// <summary>
            /// Approve or reject articles (Admin only)
            /// </summary>
            [HttpPost("review")]
            public IActionResult ReviewArticles([FromBody] ReviewArticleDto dto)
            {
                try
                {
                    _articleService.ReviewArticles(dto);
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
            [HttpGet("pending")]
            public IActionResult GetPendingArticles([FromQuery] int categoryId)
            {
                var articles = _articleService.GetPendingArticles(categoryId);
                return Ok(articles);
            }
        }
    }
