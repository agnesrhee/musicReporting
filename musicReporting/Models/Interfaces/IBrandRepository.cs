using musicReporting.Models.Entities;

namespace musicReporting.Models.Interfaces
{
    public interface IBrandRepository
    {
        Brand? Get(int id);
        IEnumerable<Brand> GetAll();
        Brand Add(Brand brand);
        Brand Update(Brand brand);
        void Delete(int id);
    }
}
