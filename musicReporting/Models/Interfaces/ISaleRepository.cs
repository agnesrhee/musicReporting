using musicReporting.Models.Entities;

namespace musicReporting.Models.Interfaces
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAll();
        Sale? Get(int id);
        Sale Add(Sale sale);
        Sale Update(Sale sale);
        void Delete(int id);
    }
}