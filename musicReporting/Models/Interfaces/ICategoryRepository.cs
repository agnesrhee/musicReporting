using musicReporting.Models.Entities;

namespace musicReporting.Models.Interfaces
{
    public interface ICategoryRepository
    {
        Category? Get(int id);
        IEnumerable<Category> GetAll();
        Category Add(Category category);
        Category Update(Category category);
        void Delete(int id);
    }
}
