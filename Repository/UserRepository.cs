using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models.Domain;

namespace WebAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            this._db = db;
        }
        
        public Task<bool> AuthenticationAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
        
        public async Task<bool> AddUserAsync(User user)
        {
            this._db!.Users!.Add(user);
            var isAdded = await this._db.SaveChangesAsync() > 0;
            return isAdded;
        }
        
        public async Task<bool> DeleteUserAsync(User user)
        {
            this._db!.Users!.Remove(user);
            var isDeleted = await this._db.SaveChangesAsync() > 0;
            return isDeleted;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await this._db!.Users!.AsNoTracking().ToListAsync();
            return users;
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var user = await this._db!.Users!.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            return user!;
        }

        public async Task<bool> UpdateUserAsync(Guid id, User user)
        {
            var userToUpdate = await this._db!.Users!.FirstOrDefaultAsync(u => u.Id == id);

            userToUpdate.Username = user.Username ?? userToUpdate.Username;
            userToUpdate.Password = user.Password ?? userToUpdate.Password;
            userToUpdate.EmailAddress = user.EmailAddress ?? userToUpdate.EmailAddress;
            userToUpdate.FirstName = user.FirstName ?? userToUpdate.FirstName;
            userToUpdate.LastName = user.LastName ?? userToUpdate.LastName;

            this._db!.Users!.Update(userToUpdate);
            this._db.Entry(userToUpdate).State = EntityState.Modified;
            var isUpdated = await this._db.SaveChangesAsync() > 0;
            return isUpdated;
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            var exist = await this._db!.Users!.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);
            return exist!;
        }
    }
}
