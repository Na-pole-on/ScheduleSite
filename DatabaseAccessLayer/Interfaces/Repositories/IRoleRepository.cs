using DatabaseAccessLayer.Entities.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
        Task<Role?> GetByName(string name);
        Task Create(Role entity);
    }
}
