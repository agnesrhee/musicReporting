using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;

namespace musicReporting.Models.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _db;

        public RoleRepository(AppDbContext db)
        {
            _db = db;
        }

        public Role? Get(int id)
        {
            return _db.Roles.Find(id);
        }

        public Role? GetByCode(string code)
        {
            return _db.Roles.FirstOrDefault(r => r.Code == code);
        }
        public IEnumerable<Role> GetAll()
        {
            return _db.Roles.ToList();
        }

        public Role Add(Role role)
        {
            _db.Roles.Add(role);
            _db.SaveChanges();
            return role;
        }

        public Role Update(Role role)
        {
            var existingRole = _db.Roles.Find(role.Id);
            if (existingRole == null)
            {
                throw new Exception($"Role with Id {role.Id} not found.");
            }

            existingRole.Id = role.Id;
            existingRole.Code = role.Code;
            existingRole.Description = role.Description;

            _db.SaveChanges();
            return existingRole;
        }

        public void Delete(int id)
        {
            var role = _db.Roles.Find(id);
            if (role != null)
            {
                _db.Roles.Remove(role);
                _db.SaveChanges();
            }
        }
    }
}
