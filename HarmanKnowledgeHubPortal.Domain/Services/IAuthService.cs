using HarmanKnowledgeHubPortal.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Services
{
        public interface IAuthService
        {
            AuthResponseDto Register(RegisterDto dto);
            AuthResponseDto Login(LoginDto dto);
        }
    }
