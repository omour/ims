namespace ImsForPresentation.Models
{
    public class Brand : IdentityUsed
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string BrandLogo { get; set; }
        public string BrandWebSiteUrl { get; set; }
    }
}