using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO;

namespace WebAPI.Repository
{
    public class WalkRepository : IWalkRepository
    {
        private readonly AppDbContext _db;
        public WalkRepository(AppDbContext db)
        {
            this._db = db;
        }
        
        public async Task<bool> AddAsync(Walk walk)
        {
            this._db!.Walks!.Add(walk);
            var isAdded = await this._db.SaveChangesAsync() > 0;
            return isAdded;
        }

        public async Task<bool> DeleteAsync(Walk walk)
        {
            this._db!.Walks!.Remove(walk);
            var isDeleted = await this._db.SaveChangesAsync() > 0;
            return isDeleted;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            var walks = await this._db!.Walks!.AsNoTracking().ToListAsync();
            return walks;
        }

        public async Task<Walk> GetByIdAsync(Guid id)
        {
            var walk = await this._db!.Walks!.AsNoTracking()
                .Include(x => x.Region)
                .Include(i => i.WalkDifficulty)
                .FirstOrDefaultAsync(w => w.Id == id);
            return walk!;
        }

        public Task<Walk> GetByNameAsync(Walk walk)
        {
            var exist = this._db!.Walks!.AsNoTracking().FirstOrDefaultAsync(w => w.Name == walk.Name);
            return exist!;
        }

        public async Task<bool> UpdateAsync(Guid id, Walk walk)
        {
            var updateWalk = await this._db!.Walks!.FirstOrDefaultAsync(w => w.Id == id);

            updateWalk.Name = walk.Name;
            updateWalk.Length = walk.Length;
            updateWalk.RegionId = walk.RegionId;
            updateWalk.WalkDifficultyId = walk.WalkDifficultyId;

            this._db!.Walks!.Update(updateWalk);
            this._db.Entry(updateWalk).State = EntityState.Modified;
            var isUpdated = await this._db.SaveChangesAsync() > 0;
            return isUpdated;
        }
    }
}
