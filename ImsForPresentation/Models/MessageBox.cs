using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ImsForPresentation.Models
{
    public class MessageBox : IdentityUsed
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public string RoleId { get; set; }
        public int MessageStatusId { get; set; }
        public string ReceivedBy { get; set; }

        [ForeignKey("HouseId")]
        public House House { get; set; }

        [ForeignKey("RoleId")]
        public IdentityRole IdentityRole { get; set; }

        [ForeignKey("MessageStatusId")]
        public MessageStatus MessageStatus { get; set; }

        [ForeignKey("ReceivedBy")]
        public ApplicationUser MessageReceivedByApplicationUser { get; set; }


    }
}