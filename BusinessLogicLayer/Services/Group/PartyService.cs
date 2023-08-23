using BusinessLogicLayer.Dtos.Dates;
using BusinessLogicLayer.Dtos.Parties;
using BusinessLogicLayer.Dtos.Profiles;
using BusinessLogicLayer.Interfaces;
using DatabaseAccessLayer.Entities.Parties;
using DatabaseAccessLayer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Group
{
    internal class PartyService: IPartyService
    {
        private IUnitOfWork _unitOfWork;

        public PartyService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<PartyDTO?> GetById(string id)
        {
            Party? party = await _unitOfWork.Parties.GetById(id);

            if (party is not null)
                return new PartyDTO
                {
                    Id = party.Id,
                    Name = party.Name,
                    Description = party.Description,
                    NameTeacher = party.NameTeacher,
                    PartyIdentifier = party.PartyIdentifier,
                    Students = party.Students.Select(s => new StudentDTO
                    {
                        Id = s.Id,
                        Amount = s.Amount,
                        DateOfBirth = s.DateOfBirth,
                        Email = s.Email,
                        NormalizedUserName = s.NormalizedUserName,
                        PhoneNumber = s.PhoneNumber,
                        UserName = s.UserName,
                    })
                };

            return null;
        }

        public async Task<PartyDTO?> GetByPartyId(string partyId)
        {
            Party? party = await _unitOfWork.Parties.GetByPartyId(partyId);

            if (party is not null)
                return new PartyDTO
                {
                    Id = party.Id,
                    Name = party.Name,
                    Description = party.Description,
                    NameTeacher = party.NameTeacher,
                    PartyIdentifier = party.PartyIdentifier,
                    Students = party.Students.Select(s => new StudentDTO
                    {
                        Id = s.Id,
                        Amount = s.Amount,
                        DateOfBirth = s.DateOfBirth,
                        Email = s.Email,
                        NormalizedUserName  = s.NormalizedUserName,
                        PhoneNumber = s.PhoneNumber,
                        UserName = s.UserName,
                    })
                };

            return null;
        } 

        public async Task Create(PartyDTO dto)
        {
            Party party = new Party
            {
                Name = dto.Name,
                Description = dto.Description,
                PartyIdentifier = DateTime.Now.ToString("yyMMddHHmm"),
                Teacher = await _unitOfWork.Teachers.GetByName(dto.NameTeacher)
            };

            await _unitOfWork.Parties.Create(party);
            await _unitOfWork.SaveAsync();
        }

        public async Task Add(StudentDTO dto)
        {

        }

        public async Task Remove(StudentDTO dto)
        {

        }
    }
}
