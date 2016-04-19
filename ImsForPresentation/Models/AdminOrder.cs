using System.ComponentModel.DataAnnotations.Schema;

namespace ImsForPresentation.Models
{
    public class AdminOrder : IdentityUsed
    {
        public int Id { get; set; }
        public int FromHouseId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
        public int? ToHouseId { get; set; }
        public int AdminOrderStatusId { get; set; }
        public string ReceivedById { get; set; }

        [ForeignKey("FromHouseId")]
        public House FromHouse { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("ToHouseId")]
        public House ToHouse { get; set; }

        [ForeignKey("AdminOrderStatusId")]
        public AdminOrderStatus AdminOrderStatus { get; set; }

        [ForeignKey("ReceivedById")]
        public ApplicationUser RecivedByApplicationUser { get; set; }
    }
}