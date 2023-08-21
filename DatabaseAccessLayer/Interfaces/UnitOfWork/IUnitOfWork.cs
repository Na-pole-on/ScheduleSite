using DatabaseAccessLayer.Entities.Profiles;
using DatabaseAccessLayer.Factories;
using DatabaseAccessLayer.Interfaces.Repositories;
using DatabaseAccessLayer.Interfaces.SignIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Interfaces.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        Factory<Student> Students { get; }
        Factory<Teacher> Teachers { get; }

        ISignIn<User> SignInManager { get; }

        IRoleRepository Roles { get; }

        IDateRepository Dates { get; }

        IPartyRepository Parties { get; }

        Task SaveAsync();
    }
}
