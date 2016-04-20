using System.ComponentModel.DataAnnotations.Schema;

namespace ImsForPresentation.Models
{
    public class Feature : IdentityUsed
    {
        public int Id { get; set; }
        public int FeaturePaletteId { get; set; }
        public string ProductFeatureName { get; set; }
        public string ProductFeature { get; set; }
        [ForeignKey("FeaturePaletteId")]
       
        public virtual FeaturePalette FeaturePalette { get; set; }
    }
}