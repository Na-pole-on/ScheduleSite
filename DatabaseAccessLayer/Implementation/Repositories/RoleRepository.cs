using DatabaseAccessLayer.Database;
using DatabaseAccessLayer.Entities.Profiles;
using DatabaseAccessLayer.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Implementation.Repositories
{
    internal class RoleRepository : IRoleRepository
    {
        private AppDatabase db;

        public RoleRepository(AppDatabase db) => this.db = db;

        public IEnumerable<Role> GetAll() => db.Roles
            .Include(r => r.Users);

        public async Task<Role?> GetByName(string id) => await db.Roles
            .FirstOrDefaultAsync(ur => ur.Name == id);

        public async Task Create(Role entity)
        {
            Role? role = await GetByName(entity.Name);

            if (role is null)
                await db.Roles.AddAsync(entity);
        }
    }
}
