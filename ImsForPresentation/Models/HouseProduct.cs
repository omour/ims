namespace ImsForPresentation.Models
{
    public class HouseProduct : IdentityUsed
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public int ProductId { get; set; }
        public int ProductBatchId { get; set; }
        public int OrderId { get; set; }
        public int ShelfId { get; set; }
        public string ShelfRow { get; set; }
        public string ShelfCol { get; set; }
        public decimal ProductStock { get; set; }
    }
}