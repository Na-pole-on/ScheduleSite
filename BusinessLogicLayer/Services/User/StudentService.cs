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
                    Party = new PartyDTO
                    {
                        Id = student.Party.Id,
                        Description = student.Party.Description,
                        Name = student.Party.Name,
                        NameTeacher = student.Party.NameTeacher,
                        PartyIdentifier = student.Party.PartyIdentifier
                    },
                    PartyIdentifier = student.PartyIdentifier
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
                    Party = new PartyDTO
                    {
                        Id = student.Party.Id,
                        Description = student.Party.Description,
                        Name = student.Party.Name,
                        NameTeacher = student.Party.NameTeacher,
                        PartyIdentifier = student.Party.PartyIdentifier
                    },
                    PartyIdentifier = student.PartyIdentifier
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
                    Party = new PartyDTO
                    {
                        Id = student.Party.Id,
                        Description = student.Party.Description,
                        Name = student.Party.Name,
                        NameTeacher = student.Party.NameTeacher,
                        PartyIdentifier = student.Party.PartyIdentifier
                    },
                    PartyIdentifier = student.PartyIdentifier
                };

            return null;
        }

        public async Task Create(Student entity)
        {
            Student student = new Student
            {
                Id = entity.Id,
                DateOfBirth = entity.DateOfBirth,
                Email = entity.Email,
                UserName = entity.UserName,
                LockoutEnabled = entity.LockoutEnabled,
                NormalizedEmail = entity.NormalizedEmail,
                NormalizedUserName = entity.NormalizedUserName,
                PasswordHash = entity.PasswordHash,
                PhoneNumber = entity.PhoneNumber,
                PhoneNumberConfirmed = entity.PhoneNumberConfirmed,
                Role = await _unitOfWork.Roles.GetByName(entity.Role.Name)
            };

            await _unitOfWork.Teachers.Create(student);
            await _unitOfWork.SaveAsync();
        }
    }
}
