using HarmanKnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetByEmail(string email);
        User GetById(int id);
        void Add(User user);
        bool Exists(string email);

    }
}
