using System.ComponentModel.DataAnnotations.Schema;

namespace ImsForPresentation.Models
{
    public class HouseUser : IdentityUsed
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public string UserId { get; set; }

        [ForeignKey("HouseId")]
        public House House { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUserId { get; set; }
    }
}