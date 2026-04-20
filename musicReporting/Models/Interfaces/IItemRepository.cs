using musicReporting.Models.Entities;

namespace musicReporting.Models.Interfaces
{
    public interface IItemRepository
    {
        Item? Get(int id);
        IEnumerable<Item> GetAll();
        Item Add(Item item);
        Item Update(Item item);
        void Delete(int id);
    }
}
