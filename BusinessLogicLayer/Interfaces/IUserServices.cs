using BusinessLogicLayer.Dtos.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserServices<TUser>
        where TUser : UserDTO
    {
        Task<TUser?> GetById(string id);
        Task<TUser?> GetByName(string name);
        Task<TUser?> GetByEmail(string email);
        Task Create(TUser entity);
    }
}
