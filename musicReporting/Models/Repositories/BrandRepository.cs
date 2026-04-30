using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;

namespace musicReporting.Models.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _db;

        public BrandRepository(AppDbContext db)
        {
            _db = db;
        }

        public Brand? Get(int id)
        {
            return _db.Brands.Find(id);
        }

        public Brand? GetByName(string name)
        {
            return _db.Brands.FirstOrDefault(b => b.Name == name);
        }

        public IEnumerable<Brand> GetAll()
        {
            return _db.Brands.ToList();
        }

        public Brand Add(Brand brand)
        {
            _db.Brands.Add(brand);
            _db.SaveChanges();
            return brand;
        }

        public Brand Update(Brand brand)
        {
            var existingBrand = _db.Brands.Find(brand.Id);
            if (existingBrand == null)
            {
                throw new Exception($"Brand with Id {brand.Id} not found.");
            }

            existingBrand.Id = brand.Id;
            existingBrand.Name = brand.Name;
            existingBrand.Description = brand.Description;

            _db.SaveChanges();
            return existingBrand;
        }

        public void Delete(int id)
        {
            var brand = _db.Brands.Find(id);
            if (brand != null)
            {
                _db.Brands.Remove(brand);
                _db.SaveChanges();
            }
        }
    }
}
