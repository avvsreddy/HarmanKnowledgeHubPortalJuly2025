using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Entities
{

    public class SubmittedUrl
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsApproved { get; set; } = false;

        public string Description { get; set; }
        public DateTime SubmittedOn { get; set; } = DateTime.UtcNow;
    }
}