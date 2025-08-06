using HarmanKnowledgeHubPortal.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
        public interface IArticleService
        {
            void ReviewArticles(ReviewArticleDto dto); // Approve or Reject
           
        }
    }

