using HarmanKnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Repositories
{
    public interface IArticlesRepository
    {

        void Submit(Article article);
        void Update(Article article);

        void Reject(List<int> articleIds);

        void Approve(List<int> articleIds);
        List<Article> Browse(int categoryId, string tag);
        List<Article> Review(int categoryId);



        Task SubmitAsync(Article article);
        Task UpdateAsync(Article article);
        Task RejectAsync(List<int> articleIds);
        Task ApproveAsync(List<int> articleIds);

        Task<List<Article>> BrowseAsync(int categoryId, string tag);
        Task<List<Article>> ReviewAsync(int categoryId);

    }
}