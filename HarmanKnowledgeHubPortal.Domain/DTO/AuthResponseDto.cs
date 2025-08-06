using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.DTO
{
    public class AuthResponseDto
        {
            public string Token { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
            public List<string> Roles { get; set; }
        }
    }

