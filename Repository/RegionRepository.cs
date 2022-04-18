using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO;

namespace WebAPI.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly AppDbContext? _db;

        public RegionRepository(AppDbContext db)
        {
            this._db = db;
        }

        public async Task<bool> DeleteAsync(Region region)
        {
            this._db!.Regions!.Remove(region!);
            var isDeleted = await this._db!.SaveChangesAsync() > 0;
            return isDeleted;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await this._db!.Regions!.AsNoTracking().ToListAsync(); 
        }

        public async Task<Region> GetByIdAsync(Guid id)
        {
            var region = await this._db!.Regions!.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
            return region!;
        }

        public Task<Region> GetByNameAsync(Region region)
        {
            var exist = this._db!.Regions!.FirstOrDefaultAsync(r => r.Name == region.Name);
            return exist!;
        }

        public async Task<bool> InsertAsync(Region region)
        {
            this._db!.Regions!.Add(region);
            var isAdded = await this._db.SaveChangesAsync() > 0;
            return isAdded;
        }

        public async Task<bool> UpdateAsync(Guid id, Region region)
        {
            var updateRegion = await this._db!.Regions!.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);

            updateRegion.Code = region.Code ?? updateRegion.Code;
            updateRegion.Name = region.Name ?? updateRegion.Name;
            updateRegion.Area = region.Area ?? updateRegion.Area;
            updateRegion.Lat = region.Lat ?? updateRegion.Lat;
            updateRegion.Long = region.Long ?? updateRegion.Long;
            updateRegion.Population = region.Population ?? updateRegion.Population;

            this._db.Regions!.Update(updateRegion);
            this._db.Entry(updateRegion).State = EntityState.Modified;
            var isUpdated = await this._db.SaveChangesAsync() > 0;
            
            return isUpdated;
        }
    }
}
