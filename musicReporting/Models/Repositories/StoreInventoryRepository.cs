using Microsoft.EntityFrameworkCore;
using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;

namespace musicReporting.Models.Repositories
{
    public class StoreInventoryRepository :IStoreInventoryRepository
    {
        private readonly AppDbContext _db;

        public StoreInventoryRepository(AppDbContext db)
        {
            _db = db;
        }

        public StoreInventory? Get(int id)
        {
            return _db.Inventories.FirstOrDefault(si => si.Id == id);
        }
        public StoreInventory? GetByItemId(int itemId)
        {
            return _db.Inventories.FirstOrDefault(i => i.ItemId == itemId);
        }
        public StoreInventory? GetByStoreId(int storeId)
        {
            return _db.Inventories.FirstOrDefault(si => si.StoreId == storeId);
        }
        public IEnumerable<StoreInventory> GetAll()
        {
            return _db.Inventories.Include(si => si.Store).Include(si => si.Item).ToList();
        }
        public StoreInventory Add(StoreInventory storeInventory)
        {
            _db.Inventories.Add(storeInventory);
            _db.SaveChanges();
            return storeInventory;
        }
        public StoreInventory Update(StoreInventory storeInventory)
        {
            var existingSI = _db.Inventories.Find(storeInventory.Id);
            if (existingSI == null)
            {
                throw new Exception($"StoreInventory with Id {storeInventory.Id} not found.");
            }

            existingSI.Id = storeInventory.Id;
            existingSI.StoreId = storeInventory.StoreId;
            existingSI.ItemId = storeInventory.ItemId;
            existingSI.QuantityOnHand = storeInventory.QuantityOnHand;

            _db.SaveChanges();
            return existingSI;
        }
        public void Delete(int id)
        {
                var storeInventory = _db.Inventories.Find(id);
                if (storeInventory != null)
                {
                    _db.Inventories.Remove(storeInventory);
                    _db.SaveChanges();
            }
        }
        public void Delete(StoreInventory storeInventory)
        {
            _db.Inventories.Remove(storeInventory);
            _db.SaveChanges();
        }
    }
}
