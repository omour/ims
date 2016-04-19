namespace ImsForPresentation.Models
{
    public class Category : IdentityUsed
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryLogo { get; set; }
    }
}