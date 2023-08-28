using BusinessLogicLayer.Cryptography;
using BusinessLogicLayer.Dtos.Parties;
using BusinessLogicLayer.Dtos.Profiles;
using BusinessLogicLayer.Interfaces;
using DatabaseAccessLayer.Entities.Profiles;
using DatabaseAccessLayer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.UserServices
{
    internal class StudentService: IUserServices<StudentDTO>
    {
        private IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<StudentDTO?> GetById(string id)
        {
            Student? student = await _unitOfWork.Students.GetById(id);

            if (student is not null)
                return new StudentDTO
                {
                    Id = student.Id,
                    DateOfBirth = student.DateOfBirth,
                    Email = student.Email,
                    UserName = student.UserName,
                    LockoutEnabled = student.LockoutEnabled,
                    NormalizedEmail = student.NormalizedEmail,
                    NormalizedUserName = student.NormalizedUserName,
                    PasswordHash = student.PasswordHash,
                    PhoneNumber = student.PhoneNumber,
                    PhoneNumberConfirmed = student.PhoneNumberConfirmed,
                    Amount = student.Amount,
                    Role = new RoleDTO
                    {
                        Id = student.Role.Id,
                        Name = student.Role.Name,
                        NormalizedName = student.Role.NormalizedName,
                    },
                    Parties = (student.Parties is not null)
                        ? student.Parties.Select(p => new PartyDTO
                        {
                            Id = p.Id,
                            Description = p.Description,
                            Name = p.Name,
                            PartyIdentifier = p.PartyIdentifier,
                            NameTeacher = p.NameTeacher,
                        })
                        : null
                };

            return null;
        }

        public async Task<StudentDTO?> GetByName(string name)
        {
            Student? student = await _unitOfWork.Students.GetByName(name.ToUpper());

            if (student is not null)
                return new StudentDTO
                {
                    Id = student.Id,
                    DateOfBirth = student.DateOfBirth,
                    Email = student.Email,
                    UserName = student.UserName,
                    LockoutEnabled = student.LockoutEnabled,
                    NormalizedEmail = student.NormalizedEmail,
                    NormalizedUserName = student.NormalizedUserName,
                    PasswordHash = student.PasswordHash,
                    PhoneNumber = student.PhoneNumber,
                    PhoneNumberConfirmed = student.PhoneNumberConfirmed,
                    Amount = student.Amount,
                    Role = new RoleDTO
                    {
                        Id = student.Role.Id,
                        Name = student.Role.Name,
                        NormalizedName = student.Role.NormalizedName,
                    },
                    Parties = (student.Parties is not null)
                    ? student.Parties.Select(p => new PartyDTO
                    {
                        Id = p.Id,
                        Description = p.Description,
                        Name = p.Name,
                        PartyIdentifier = p.PartyIdentifier,
                        NameTeacher = p.NameTeacher,
                    })
                    : null
                };

            return null;
        }

        public async Task<StudentDTO?> GetByEmail(string email)
        {
            Student? student = await _unitOfWork.Students.GetByEmail(email.ToUpper());

            if (student is not null)
                return new StudentDTO
                {
                    Id = student.Id,
                    DateOfBirth = student.DateOfBirth,
                    Email = student.Email,
                    UserName = student.UserName,
                    LockoutEnabled = student.LockoutEnabled,
                    NormalizedEmail = student.NormalizedEmail,
                    NormalizedUserName = student.NormalizedUserName,
                    PasswordHash = student.PasswordHash,
                    PhoneNumber = student.PhoneNumber,
                    PhoneNumberConfirmed = student.PhoneNumberConfirmed,
                    Amount = student.Amount,
                    Role = new RoleDTO
                    {
                        Id = student.Role.Id,
                        Name = student.Role.Name,
                        NormalizedName = student.Role.NormalizedName,
                    },
                    Parties = (student.Parties is not null)
                    ? student.Parties.Select(p => new PartyDTO
                    {
                        Id = p.Id,
                        Description = p.Description,
                        Name = p.Name,
                        PartyIdentifier = p.PartyIdentifier,
                        NameTeacher = p.NameTeacher,
                    })
                    : null
                };

            return null;
        }

        public async Task Create(StudentDTO entity)
        {
            Student student = new Student
            {
                DateOfBirth = entity.DateOfBirth,
                Email = entity.Email,
                UserName = entity.UserName,
                NormalizedEmail = entity.Email.ToUpper(),
                NormalizedUserName = entity.UserName.ToUpper(),
                PasswordHash = Cipher.Encrypt(entity.PasswordHash),
                PhoneNumber = entity.PhoneNumber,
                Amount = entity.Amount,
                Role = await _unitOfWork.Roles.GetByName("Student")
            };

            await _unitOfWork.Students.Create(student);
            await _unitOfWork.SaveAsync();
        }
    }
}
