using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
    public class SubmittedUrlService : ISubmittedUrlService
    {
        private readonly ISubmittedUrlRepository _repository;

        public SubmittedUrlService(ISubmittedUrlRepository repository)
        {
            _repository = repository;
        }

        public async Task<SubmittedUrl> SubmitUrlAsync(SubmitUrlDTO dto)
        {
            var url = new SubmittedUrl
            {
                Title = dto.Title,
                Url = dto.Url,
                CategoryId = dto.CategoryId,
                UserId = dto.UserId,
                Description = dto.Description,
                IsApproved = false
            };

            await _repository.AddAsync(url);
            return url;
        }

        public async Task<IEnumerable<SubmittedUrl>> GetApprovedUrlsAsync()
        {
            return await _repository.GetAllApprovedAsync();
        }
    }
}