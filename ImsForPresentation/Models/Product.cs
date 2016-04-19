using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImsForPresentation.Models
{
    public class Product : IdentityUsed
    {
        public int Id { get; set; }
        
        [Required]
        public string ProductName { get; set; }
        public string ProductModel { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int SiUnitId { get; set; }
        public int FeaturePaletteId { get; set; }
        public decimal Stock { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        [ForeignKey("SiUnitId")]
        public SiUnit SiUnit { get; set; }

        [ForeignKey("FeaturePaletteId")]
        public FeaturePalette FeaturePalette { get; set; }
    }
}