using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;

namespace musicReporting.Models.Repositories
{
    public class StoreRepository :IStoreRepository
    {
        private readonly AppDbContext _db;

        public StoreRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Store> GetAll()
        {
            return _db.Stores.ToList();
        }

        public Store? Get(int id)
        {
            return _db.Stores.Find(id);
        }

        public Store? GetByName(string? name)
        {
            return _db.Stores.FirstOrDefault(s => s.StoreName == name);
        }

        public Store Add(Store store)
        {
            _db.Stores.Add(store);
            _db.SaveChanges();
            return store;
        }

        public Store Update(Store store)
        {
            var existingStore = _db.Stores.Find(store.Id);
            if (existingStore == null)
            {
                throw new Exception($"Store with Id {store.Id} not found.");
            }

            existingStore.StoreName = store.StoreName;
            existingStore.PhoneNumber = store.PhoneNumber;
            existingStore.AddressLine1 = store.AddressLine1;
            existingStore.AddressLine2 = store.AddressLine2;
            existingStore.City = store.City;
            existingStore.State = store.State;
            existingStore.ZipCode = store.ZipCode;

            _db.SaveChanges();
            return existingStore;
        }

        public void Delete(int id)
        {
            var store = _db.Stores.Find(id);
            if (store != null)
            {
                _db.Stores.Remove(store);
                _db.SaveChanges();
            }
        }

        public void Delete(Store store)
        {
            var existingStore = _db.Stores.Find(store.Id);
            if (existingStore != null)
            {
                _db.Stores.Remove(existingStore);
                _db.SaveChanges();
            }
        }
    }
}
