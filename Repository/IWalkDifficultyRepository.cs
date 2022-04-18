using WebAPI.Models.Domain;

namespace WebAPI.Repository
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();
        Task<WalkDifficulty> GetByIdAsync(Guid id);
        Task<bool> AddAsync(WalkDifficulty walkDifficulty);
        Task<bool> UpdateAsync(WalkDifficulty walkDifficulty);
        Task<bool> DeleteAsync(WalkDifficulty walkDifficulty);
        Task<bool> GetByCodeAsync(string Code);
    }
}
