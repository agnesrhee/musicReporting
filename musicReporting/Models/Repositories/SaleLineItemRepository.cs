using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;

namespace musicReporting.Models.Repositories
{
    public class SaleLineItemRepository : ISaleLineItemRepository
    {
        private readonly AppDbContext _db;

        public SaleLineItemRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<SaleLineItem> GetAll()
        {
            return _db.SaleLineItems.ToList();
        }

        public SaleLineItem? Get(int id)
        {
            return _db.SaleLineItems.Find(id);
        }

        public SaleLineItem Add(SaleLineItem saleLineItem)
        {
            _db.SaleLineItems.Add(saleLineItem);
            _db.SaveChanges();
            return saleLineItem;
        }
    }
}