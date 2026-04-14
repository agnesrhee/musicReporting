using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;

namespace musicReporting.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User? Get(int id)
        {
            return _db.Users.Find(id);
        }

        public User? GetByName(string? firstName, string? lastName)
        {
            return _db.Users.FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName);
        }

        public User? GetByUserId(string? id)
        {
            return _db.Users.FirstOrDefault(u => u.UserId == id);
        }

        public User? GetByEmailAddress(string? emailAddress)
        {
            return _db.Users.FirstOrDefault(u => u.Email == emailAddress);
        }

        public User Add(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }

        public User Update(User user)
        {
            var existingUser = _db.Users.Find(user.Id);
            if (existingUser == null)
            {
                throw new Exception($"User with Id {user.Id} not found.");
            }

            existingUser.StoreId = user.StoreId;
            existingUser.UserId = user.UserId;
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;

            _db.SaveChanges();
            return existingUser;
        }

        public void Delete(int id)
        {
            var user = _db.Users.Find(id);
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }

        public void Delete(User user)
        {
            var existingUser = _db.Users.Find(user.Id);
            if (existingUser != null)
            {
                _db.Users.Remove(existingUser);
                _db.SaveChanges();
            }
        }
    }
}