using System.ComponentModel.DataAnnotations.Schema;

namespace ImsForPresentation.Models
{
    public class ProductSinglePartNumber : IdentityUsed
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Batch { get; set; }

        [ForeignKey("ProductId")]
        public HouseProduct HouseProduct { get; set; }
    }
}