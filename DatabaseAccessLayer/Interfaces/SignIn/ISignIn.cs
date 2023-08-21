using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Interfaces.SignIn
{
    public interface ISignIn<User>
    {
        bool IsExists(string email);
        User? GetUser(string email, string password);
        Task SignIn(User entity);
        Task SignOut();
    }
}
