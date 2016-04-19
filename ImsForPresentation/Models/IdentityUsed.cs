using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImsForPresentation.Models
{
    public class IdentityUsed
    {
        [StringLength(5120)]
        public string Description { get; set; }
        public Boolean ActiveStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("CreatedBy")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}