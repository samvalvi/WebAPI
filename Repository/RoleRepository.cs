using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models.Domain;

namespace WebAPI.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _db;

        public RoleRepository(AppDbContext appDbContext)
        {
            this._db = appDbContext;
        }
        public async Task<bool> AddAsync(Role role)
        {
            this._db!.Roles!.Add(role);
            var isAdded = await this._db.SaveChangesAsync() > 0;
            return isAdded;
        }

        public async Task<bool> DeleteAsync(Role role)
        {
            this._db!.Roles.Remove(role!);
            var isDeleted = await this._db.SaveChangesAsync() > 0;
            return isDeleted;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var roles = await this._db!.Roles!.AsNoTracking().ToListAsync();
            return roles;
        }

        public Task<Role> GetByIdAsync(Guid id)
        {
            var role = this._db!.Roles!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return role!;
        }
        public async Task<bool> UpdateAsync(Guid id, Role role)
        {
            var roleToUpdate = await this._db!.Roles!.FindAsync(id);

            roleToUpdate.UserRole = role.UserRole ?? roleToUpdate.UserRole;

            this._db!.Roles.Update(roleToUpdate);
            this._db.Entry(roleToUpdate).State = EntityState.Modified;
            var isUpdated = await this._db.SaveChangesAsync() > 0;
            return isUpdated;
        }
    }
}
