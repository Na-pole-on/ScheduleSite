using BusinessLogicLayer.Cryptography;
using BusinessLogicLayer.Interfaces;
using DatabaseAccessLayer.Entities.Profiles;
using DatabaseAccessLayer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Authentication
{
    internal class AuthenticationService: IAuthenticationService
    {
        private IUnitOfWork _unitOfWork;

        public AuthenticationService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public bool IsExists(string email) => _unitOfWork.SignInManager
            .IsExists(email);

        public async Task<int> SignIn(string email, string password)
        {
            IEnumerable<User>? users = _unitOfWork.SignInManager
                .GetUser(email, Cipher.Encrypt(password));

            if (users is not null)
            {
                User? user = users
                    .FirstOrDefault(u => u.Email == email && u.PasswordHash == Cipher.Encrypt(password));

                if (user is not null)
                {
                    await _unitOfWork.SignInManager
                        .SignIn(user);

                    if (user.Role.Name == "Student")
                        return 1;

                    if (user.Role.Name == "Teacher")
                        return 2;
                }
            }

            return 0;
        }

        public async Task SignOut() => await _unitOfWork.SignInManager
            .SignOut();
    }
}
