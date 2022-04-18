using WebAPI.Models.Domain;

namespace WebAPI.Repository
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetByIdAsync(Guid id);
        Task<bool> InsertAsync(Region region);
        Task<bool> UpdateAsync(Guid id, Region region);
        Task<bool> DeleteAsync(Region region);
        Task<Region> GetByNameAsync(Region region);
    }
}
