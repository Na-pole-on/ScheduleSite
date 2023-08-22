using BusinessLogicLayer.Dtos.Parties;
using BusinessLogicLayer.Dtos.Profiles;
using DatabaseAccessLayer.Entities.Parties;
using DatabaseAccessLayer.Entities.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPartyService
    {
        Task<PartyDTO?> GetById(string id);
        Task<PartyDTO?> GetByPartyId(string partyId);
        Task Add(StudentDTO entity);
        Task Remove(StudentDTO entity);
        Task Create(PartyDTO entity);
    }
}
