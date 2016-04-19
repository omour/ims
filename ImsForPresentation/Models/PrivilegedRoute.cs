using System.ComponentModel.DataAnnotations;

namespace ImsForPresentation.Models
{
    public class PrivilegedRoute : IdentityUsed
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string RouteName { get; set; }
    }
}