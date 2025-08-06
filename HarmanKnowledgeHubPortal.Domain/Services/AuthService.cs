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

            public AuthResponseDto Register(RegisterDto dto)
            {
                if (_userRepo.Exists(dto.Email))
                    throw new Exception("Email already registered");

                var user = new User
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = dto.Password, 
                    DateTimeCreated = DateTime.UtcNow,
                    Roles = dto.Roles.Select(roleName =>
                        _roleRepo.GetByName(roleName) ?? throw new Exception($"Role {roleName} not found")).ToList()
                };

                _userRepo.Add(user);

                return new AuthResponseDto
                {
                    Email = user.Email,
                    Name = user.Name,
                    Roles = user.Roles.Select(r => r.Name).ToList(),
                    Token = "mock-jwt-token" // Replace with real JWT logic
                };
            }

            public AuthResponseDto Login(LoginDto dto)
            {
                var user = _userRepo.GetByEmail(dto.Email);
                if (user == null || user.Password != dto.Password)
                    throw new Exception("Invalid credentials");

                return new AuthResponseDto
                {
                    Email = user.Email,
                    Name = user.Name,
                    Roles = user.Roles.Select(r => r.Name).ToList(),
                    Token = "mock-jwt-token" // Replace with JWT generation
                };
            }
        }
    }

