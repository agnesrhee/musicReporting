using Microsoft.EntityFrameworkCore;
using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;

namespace musicReporting.Models.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _db;

        public ItemRepository(AppDbContext db)
        {
            _db = db;
        }

        public Item? Get(int id)
        {
            return _db.Items.Find(id);

        }

        public Item? GetBySKU(string sku)
        {
            return _db.Items.FirstOrDefault(i => i.SKU == sku);
        }

        public IEnumerable<Item> GetAll()
        {
            return _db.Items.Include(i => i.Category).ToList();
        }
        public Item Add(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return item;
        }
        public Item Update(Item item)
        {
            var existingItem = _db.Items.Find(item.Id);
            if (existingItem == null)
            {
                throw new Exception($"Item with Id {item.Id} not found.");
            }

            existingItem.Id = item.Id;
            existingItem.ItemName = item.ItemName;
            existingItem.Description = item.Description;
            existingItem.Category = item.Category;
            existingItem.Price = item.Price;
            existingItem.SKU = item.SKU;
            existingItem.IsActive = item.IsActive;

            _db.SaveChanges();
            return existingItem;
        }
        public void Delete(int id)
        {
            var item = _db.Items.Find(id);
            if (item != null)
            {
                _db.Items.Remove(item);
                _db.SaveChanges();
            }
        }
    }
}
