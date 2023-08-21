﻿using BusinessLogicLayer.Dtos.Profiles;
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
    internal class TeacherService: IUserServices<TeacherDTO>
    {
        private IUnitOfWork _unitOfWork;

        public TeacherService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<TeacherDTO?> GetById(string id)
        {
            Teacher? teacher = await _unitOfWork.Teachers.GetById(id);

            if (teacher is not null)
                return new TeacherDTO
                {
                    Id = teacher.Id,
                    DateOfBirth = teacher.DateOfBirth,
                    Email = teacher.Email,
                    UserName = teacher.UserName,
                    LockoutEnabled = teacher.LockoutEnabled,
                    NormalizedEmail = teacher.NormalizedEmail,
                    NormalizedUserName = teacher.NormalizedUserName,
                    PasswordHash = teacher.PasswordHash,
                    PhoneNumber = teacher.PhoneNumber,
                    PhoneNumberConfirmed = teacher.PhoneNumberConfirmed,
                    Role = new RoleDTO
                    {
                        Id = teacher.Role.Id,
                        Name = teacher.Role.Name,
                        NormalizedName = teacher.Role.NormalizedName,
                    }
                };

            return null;
        }

        public async Task<TeacherDTO?> GetByName(string name)
        {
            Teacher? teacher = await _unitOfWork.Teachers.GetByName(name.ToUpper());

            if (teacher is not null)
                return new TeacherDTO
                {
                    Id = teacher.Id,
                    DateOfBirth = teacher.DateOfBirth,
                    Email = teacher.Email,
                    UserName = teacher.UserName,
                    LockoutEnabled = teacher.LockoutEnabled,
                    NormalizedEmail = teacher.NormalizedEmail,
                    NormalizedUserName = teacher.NormalizedUserName,
                    PasswordHash = teacher.PasswordHash,
                    PhoneNumber = teacher.PhoneNumber,
                    PhoneNumberConfirmed = teacher.PhoneNumberConfirmed,
                    Role = new RoleDTO
                    {
                        Id = teacher.Role.Id,
                        Name = teacher.Role.Name,
                        NormalizedName = teacher.Role.NormalizedName,
                    }
                };

            return null;
        }

        public async Task<TeacherDTO?> GetByEmail(string email)
        {
            Teacher? teacher = await _unitOfWork.Teachers.GetByEmail(email.ToUpper());

            if (teacher is not null)
                return new TeacherDTO
                {
                    Id = teacher.Id,
                    DateOfBirth = teacher.DateOfBirth,
                    Email = teacher.Email,
                    UserName = teacher.UserName,
                    LockoutEnabled = teacher.LockoutEnabled,
                    NormalizedEmail = teacher.NormalizedEmail,
                    NormalizedUserName = teacher.NormalizedUserName,
                    PasswordHash = teacher.PasswordHash,
                    PhoneNumber = teacher.PhoneNumber,
                    PhoneNumberConfirmed = teacher.PhoneNumberConfirmed,
                    Role = new RoleDTO
                    {
                        Id = teacher.Role.Id,
                        Name = teacher.Role.Name,
                        NormalizedName = teacher.Role.NormalizedName,
                    }
                };

            return null;
        }
    }
}
