using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities.Profiles
{
    public class User
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? PasswordHash { get; set; }
        public bool LockoutEnabled { get; set; }

        public Role? Role { get; set; }
    }
}
