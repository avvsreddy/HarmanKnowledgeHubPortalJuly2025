using HarmanKnowledgeHubPortal.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
      public interface IArticleService
    {
        /// <summary>
        /// Gets pending articles for review based on the selected category.
        /// </summary>
        /// <param name="request">Category selection request DTO.</param>
        /// <returns>List of URLs with selection flag, title, URL, and category.</returns>
        Task<List<ApproveUrlsResponseDto>> GetPendingApprovalsAsync(ApproveUrlsRequestDto request);

        /// <summary>
        /// Approves the selected articles.
        /// </summary>
        /// <param name="request">IDs of articles to approve.</param>
        /// <returns>Status code and message DTO.</returns>
        Task<ApproveRejectActionResponseDto> ApproveUrlsAsync(ApproveRejectActionRequestDto request);

        /// <summary>
        /// Rejects the selected articles.
        /// </summary>
        /// <param name="request">IDs of articles to reject.</param>
        /// <returns>Status code and message DTO.</returns>
        Task<ApproveRejectActionResponseDto> RejectUrlsAsync(ApproveRejectActionRequestDto request);
    }

}