using HarmanKnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Repositories
{
    public interface ICategoryRepository
    {
        void Create(Category category);
        List<Category> GetAll();    
        
        Category GetById(int id);

        void Update(Category category);

        void SoftDelete(int id);    
    }
}
