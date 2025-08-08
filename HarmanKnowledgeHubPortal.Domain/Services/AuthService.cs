using System;
using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Repositories;
using HarmanKnowledgeHubPortal.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
        public class AuthService : IAuthService
        {
            private readonly IUserRepository _userRepo;
            private readonly IRoleRepository _roleRepo;

            public AuthService(IUserRepository userRepo, IRoleRepository roleRepo)
            {
                _userRepo = userRepo;
                _roleRepo = roleRepo;
            }

            public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
            {
                if (await _userRepo.ExistsAsync(dto.Email))
                    throw new Exception("Email already registered");

                var roles = new List<Role>();
                foreach (var roleName in dto.Roles)
                {
                    var role = await _roleRepo.GetByNameAsync(roleName);
                    if (role == null)
                        throw new Exception($"Role '{roleName}' not found");
                    roles.Add(role);
                }

                var user = new User
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = dto.Password, 
                    DateTimeCreated = DateTime.UtcNow,
                    Roles = roles
                };

                await _userRepo.AddAsync(user);

                return new AuthResponseDto
                {
                    Email = user.Email,
                    Name = user.Name,
                    Roles = user.Roles.Select(r => r.Name).ToList(),
                    Token = "mock-jwt-token" // Replace with actual JWT generation logic
                };
            }

            public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
            {
                var user = await _userRepo.GetByEmailAsync(dto.Email);
                if (user == null || user.Password != dto.Password)
                    throw new Exception("Invalid credentials");

                return new AuthResponseDto
                {
                    Email = user.Email,
                    Name = user.Name,
                    Roles = user.Roles.Select(r => r.Name).ToList(),
                    Token = "mock-jwt-token" // Replace with actual JWT generation logic
                };
            }
        }
    }


