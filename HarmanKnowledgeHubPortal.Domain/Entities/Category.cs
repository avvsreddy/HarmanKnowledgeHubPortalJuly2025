using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [MinLength(3)]
        public string CategoryName { get; set; }

        [MaxLength(500)]
        [MinLength(5)]
        public string CategoryDescription { get; set; }

        public DateTime DateTimeCreate { get; set; }

        public bool IsDeleted { get; set; }

    }
}
