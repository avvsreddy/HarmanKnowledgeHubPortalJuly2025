using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
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

            public async Task<Role?> GetByNameAsync(string roleName)
            {
                return await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
            }

            public async Task<List<Role>> GetAllAsync()
            {
                return await _context.Roles.ToListAsync();
            }
        }
    }


