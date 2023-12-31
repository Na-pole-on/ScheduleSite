﻿using DatabaseAccessLayer.Database;
using DatabaseAccessLayer.Entities.Profiles;
using DatabaseAccessLayer.Interfaces.SignIn;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Implementation.SignIn
{
    internal class SignInManager : ISignIn<User>
    {
        private AppDatabase db;
        private IHttpContextAccessor accessor;

        public SignInManager(AppDatabase db,
            IHttpContextAccessor accessor)
        {
            this.db = db;
            this.accessor = accessor;
        }

        public bool IsExists(string email) => db.Roles
                .Select(r => r.Users)
                .Any(u => u.Any(u => u.Email == email));

        public IEnumerable<User>? GetUser(string email, string password) => db.Roles
            .Select(r => r.Users.Select(u => new User
            {
                Id = u.Id,
                Email = u.Email,
                DateOfBirth = u.DateOfBirth,
                LockoutEnabled = u.LockoutEnabled,
                NormalizedEmail = u.NormalizedEmail,
                NormalizedUserName = u.NormalizedUserName,
                PasswordHash = u.PasswordHash,
                PhoneNumber = u.PhoneNumber,
                PhoneNumberConfirmed = u.PhoneNumberConfirmed,
                UserName = u.UserName,
                Role = new Role { Name = u.Role.Name }
            }))
            .FirstOrDefault(us => us.Any(us => us.Email == email && us.PasswordHash == password));

        public async Task SignIn(User entity) => await accessor.HttpContext
            .SignInAsync(GetClaimsPrincipal(entity));

        public async Task SignOut() => await accessor.HttpContext
            .SignOutAsync();

        private ClaimsPrincipal GetClaimsPrincipal(User entity)
        {
            var claims = new List<Claim>
            {
                new Claim("Identifier", entity.Id),
                new Claim("UserName", entity.UserName),
                new Claim("Email", entity.Email),
                new Claim("PhoneNumber", entity.PhoneNumber),
                new Claim(ClaimTypes.Role, entity.Role.Name)
            };

            return new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
        }
    }
}
