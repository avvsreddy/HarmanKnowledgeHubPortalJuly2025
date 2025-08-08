using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.DTO
{
    /// <summary>
    /// Response returned after successful authentication.
    /// </summary>
    public class AuthResponseDto
    {
        /// <summary>
        /// JWT access token for the authenticated user.
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Authenticated user's email address.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Authenticated user's display name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Roles assigned to the user.
        /// </summary>
        public List<string> Roles { get; set; } = new List<string>();
    }
}

