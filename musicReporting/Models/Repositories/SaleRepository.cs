using Microsoft.EntityFrameworkCore;
using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;

namespace musicReporting.Models.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _db;

        public SaleRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Sale> GetAll()
        {
            return _db.Sales.Include(s => s.Store).Include(s => s.User).ToList();
        }

        public Sale? Get(int id)
        {
            return _db.Sales
                .Include(s => s.Store)
                .Include(s => s.User)
                .Include(s => s.LineItems)
                    .ThenInclude(li => li.Item)
                .FirstOrDefault(s => s.Id == id);
        }

        public Sale Add(Sale sale)
        {
            _db.Sales.Add(sale);
            _db.SaveChanges();
            return sale;
        }

        public Sale Update(Sale sale)
        {
            var existingSale = _db.Sales.Find(sale.Id);
            if (existingSale == null)
            {
                throw new Exception($"Sale with Id {sale.Id} not found.");
            }

            existingSale.StoreId = sale.StoreId;
            existingSale.UserId = sale.UserId;
            existingSale.SaleDate = sale.SaleDate;

            _db.SaveChanges();
            return existingSale;
        }

        public void Delete(int id)
        {
            var sale = _db.Sales
                .Include(s => s.LineItems)
                .FirstOrDefault(s => s.Id == id);

            if (sale != null)
            {
                _db.SaleLineItems.RemoveRange(sale.LineItems);
                _db.Sales.Remove(sale);
                _db.SaveChanges();
            }
        }
    }
}