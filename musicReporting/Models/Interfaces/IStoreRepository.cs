using musicReporting.Models.Entities;

namespace musicReporting.Models.Interfaces
{
    public interface IStoreRepository
    {
        Store? Get(int id);
        Store? GetByName(string? name);
        IEnumerable<Store> GetAll();
        Store Add(Store store);
        Store Update(Store store);
        void Delete(int id);
        void Delete(Store store);

    }
}
