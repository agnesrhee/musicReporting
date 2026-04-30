using musicReporting.Models.Entities;

namespace musicReporting.Models.Interfaces
{
    public interface IRoleRepository
    {
        Role? Get(int id);
        IEnumerable<Role> GetAll();
        Role Add(Role role);
        Role Update(Role role);
        void Delete(int id);
    }
}
