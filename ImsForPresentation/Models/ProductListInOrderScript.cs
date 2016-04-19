using System.ComponentModel.DataAnnotations.Schema;

namespace ImsForPresentation.Models
{
    public class ProductListInOrderScript
    {
        public int Id { get; set; }
        public int ProductOrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }

        [ForeignKey("ProductOrderId")]
        public ProductOrder ProductOrder { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}