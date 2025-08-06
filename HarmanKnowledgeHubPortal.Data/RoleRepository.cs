using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Data
{
        public class RoleRepository : IRoleRepository
        {
            private readonly AppDbContext _context;

            public RoleRepository(AppDbContext context)
            {
                _context = context;
            }

            public Role GetByName(string roleName)
            {
                return _context.Roles.FirstOrDefault(r => r.Name == roleName);
            }

            public List<Role> GetAll()
            {
                return _context.Roles.ToList();
            }
        }
    }

