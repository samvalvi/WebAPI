using WebAPI.Models.Domain;

namespace WebAPI.Repository
{
    public interface IUserRepository
    {
        Task<bool> AuthenticationAsync(string username, string password);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(Guid id);
        Task<bool> AddUserAsync(User user);
        Task<bool> UpdateUserAsync(Guid id, User user);
        Task<bool> DeleteUserAsync(User user);
        Task<User> GetUserByNameAsync(string username);
    }
}
