using WebAPI.Models.Domain;
using WebAPI.Models.DTO;

namespace WebAPI.Repository
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();
        Task<Walk> GetByIdAsync(Guid id);
        Task<bool> AddAsync(Walk walk);
        Task<bool> UpdateAsync(Guid id, Walk walk);
        Task<bool> DeleteAsync(Walk walk);
        Task<Walk> GetByNameAsync(Walk walk); 
    }
}
