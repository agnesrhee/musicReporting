namespace musicReporting.Models.Entities
{
    public class Sale
    {
        public int Id { get; set; }

        public int StoreId { get; set; }
        public Store? Store { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.Now;

        public ICollection<SaleLineItem> LineItems { get; set; } = new List<SaleLineItem>();
    }
}
