using System.ComponentModel.DataAnnotations.Schema;

namespace ImsForPresentation.Models
{
    public class ProductOrder : IdentityUsed
    {
        public int Id { get; set; }
        public int ProductOrderStatusId { get; set; }
        public int ProducerId { get; set; }

        [ForeignKey("ProductOrderStatusId")]
        public ProductOrderStatus ProductOrderStatus { get; set; }

        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}