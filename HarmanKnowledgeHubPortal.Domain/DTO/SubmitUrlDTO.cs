using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.DTO
{
    public class SubmitUrlDTO
    {
        public string Title { get; set; }        // e.g., Website name
        public string Url { get; set; }          // The actual URL
        public int CategoryId { get; set; }      // Links to a category
        
        public string Description {  get; set; }
        public int UserId { get; set; }
    }
}
