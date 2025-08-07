using HarmanKnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Repositories
{
        public interface IRoleRepository
        {
            Role GetByName(string roleName);
            List<Role> GetAll();
        }
    }

