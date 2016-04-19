using System.ComponentModel.DataAnnotations;

namespace ImsForPresentation.Models
{
    public class UserProfile : IdentityUsed
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        
        [StringLength(100)]
        public string WebSiteUrl { get; set; }
        
        [StringLength(100)]
        public string ImageUrl { get; set; }
    }
}