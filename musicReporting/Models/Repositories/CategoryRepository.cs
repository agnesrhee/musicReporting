using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;

namespace musicReporting.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _db;

        public CategoryRepository(AppDbContext db)
        {
            _db = db;
        }

        public Category? Get(int id)
        {
            return _db.Categories.Find(id);
        }
        public IEnumerable<Category> GetAll()
        {
            return _db.Categories.ToList();
        }

        public Category Add(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return category;
        }

        public Category Update(Category category)
        {
            var existingCat = _db.Categories.Find(category.Id);
            if (existingCat == null)
            {
                throw new Exception($"Category with Id {category.Id} not found.");
            }

            existingCat.Id = category.Id;
            existingCat.Name = category.Name;
            existingCat.Description = category.Description;

            _db.SaveChanges();
            return existingCat;
        }

        public void Delete(int id)
        {
            var category = _db.Categories.Find(id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
        }
    }
}
