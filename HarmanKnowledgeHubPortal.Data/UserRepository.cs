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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool Exists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public User GetByEmail(string email)
        {
            return _context.Users
                .Include(u => u.Roles)  // EAGER LOAD ROLES
                .FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return _context.Users
                .Include(u => u.Roles)  // EAGER LOAD ROLES
                .FirstOrDefault(u => u.Id == id);
        }
    }
}
