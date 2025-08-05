using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int RatingNumber {  get; set; }
        public string Review { get; set; }

        public User User { get; set; }

    }
}
