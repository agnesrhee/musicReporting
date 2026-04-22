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
            var existingStoreInventory = _db.Inventories.Find(storeInventory.Id);
            if (existingStoreInventory == null)
            {
                throw new Exception($"StoreInventory with Id {storeInventory.Id} not found.");
            }

            existingStoreInventory.StoreId = storeInventory.StoreId;
            existingStoreInventory.ItemId = storeInventory.ItemId;
            existingStoreInventory.QuantityOnHand = storeInventory.QuantityOnHand;
            existingStoreInventory.IsActive = storeInventory.IsActive;

            _db.SaveChanges();
            return existingStoreInventory;
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

        public StoreInventory? GetByStoreAndItem(int storeId, int itemId)
        {
            return _db.Inventories
                .FirstOrDefault(si => si.StoreId == storeId && si.ItemId == itemId);
        }
    }
}
