using WebAPI.Models.Domain;

namespace WebAPI.Repository
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(Guid id);
        Task<bool> AddAsync(Role role);
        Task<bool> UpdateAsync(Guid id, Role role);
        Task<bool> DeleteAsync(Role role);
    }
}
