using musicReporting.Models.Entities;

namespace musicReporting.Models.Interfaces
{
    public interface IStoreInventoryRepository
    {
        StoreInventory? Get(int id);
        StoreInventory? GetByItemId(int itemId);
        StoreInventory? GetByStoreId(int storeId);
        IEnumerable<StoreInventory> GetAll();
        StoreInventory Add(StoreInventory storeInventory);
        StoreInventory Update(StoreInventory storeInventory);
        void Delete(int id);
        void Delete(StoreInventory storeInventory);
    }
}
