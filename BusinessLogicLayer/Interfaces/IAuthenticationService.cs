using DatabaseAccessLayer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsExists(string email);
        Task<int> SignIn(string email, string password);
        Task SignOut();
    }
}
