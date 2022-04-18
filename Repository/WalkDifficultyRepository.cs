using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models.Domain;

namespace WebAPI.Repository
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly AppDbContext _db;

        public WalkDifficultyRepository(AppDbContext db)
        {
            this._db = db;
        }
        
        public async Task<bool> AddAsync(WalkDifficulty walkDifficulty)
        {
            this._db!.WalkDifficulties!.Add(walkDifficulty);
            var isAdded = await this._db.SaveChangesAsync() > 0;
            return isAdded;
        }

        public async Task<bool> DeleteAsync(WalkDifficulty walkDifficulty)
        {
            this._db!.WalkDifficulties!.Remove(walkDifficulty);
            var isDeleted = await this._db.SaveChangesAsync() > 0;
            return isDeleted;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            var walkDifficulties = await this._db!.WalkDifficulties!.AsNoTracking().ToListAsync();
            return walkDifficulties;
        }

        public Task<WalkDifficulty> GetByIdAsync(Guid id)
        {
            var walkDifficulty = this._db!.WalkDifficulties!.AsNoTracking().FirstOrDefaultAsync(w => w.Id == id);
            return walkDifficulty!;
        }

        public async Task<bool> UpdateAsync(WalkDifficulty walkDifficulty)
        {
            var difficultyToUpdate = await this._db!.WalkDifficulties!.FirstOrDefaultAsync(w => w.Id == walkDifficulty.Id);

            difficultyToUpdate.Code = walkDifficulty.Code;

            this._db!.WalkDifficulties!.Update(difficultyToUpdate);
            this._db.Entry(difficultyToUpdate).State = EntityState.Modified;
            var isUpdated = await this._db.SaveChangesAsync() > 0;
            return isUpdated;
        }
        
        public async Task<bool> GetByCodeAsync(string code)
        {
            var isExist = await this._db.WalkDifficulties!.AnyAsync(w => w.Code == code);
            return isExist;
        }
    }
}
