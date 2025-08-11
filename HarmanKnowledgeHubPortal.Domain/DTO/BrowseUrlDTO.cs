using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.DTO
{
    public class BrowseUrlDTO
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }      //review,reports
        public string PostedBy { get; set; }        // e.g., User Name or Email
        public string CategoryName { get; set; }    // e.g., "Programming", "Design"
    }
}