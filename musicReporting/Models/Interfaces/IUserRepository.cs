using musicReporting.Models.Entities;
using System.Collections.Generic;

namespace musicReporting.Models.Interfaces
{
    public interface IUserRepository
    {

        User? Get(int id);
        User? GetByName (string? firstName, string? lastName);
        User? GetByEmailAddress (string? emailAddress);
        User? GetByUserId (string? userId);
        IEnumerable<User> GetAll();
        User Add(User user);
        User Update(User user);
        void Delete(int id);
        void Delete(User user);
    }
}
