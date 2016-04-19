namespace ImsForPresentation.Models
{
    public class Feature : IdentityUsed
    {
        public int Id { get; set; }
        public int FeaturePalette { get; set; }
        public string ProductFeatureName { get; set; }
        public string ProductFeature { get; set; }
    }
}