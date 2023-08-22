using DatabaseAccessLayer.Entities.Parties;
using DatabaseAccessLayer.Entities.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Interfaces.Repositories
{
    public interface IPartyRepository
    {
        IEnumerable<Party> GetAll();
        Task<Party?> GetById(string id);
        Task<Party?> GetByPartyId(string partyId);
        Task Add(Student entity);
        Task Remove(Student entity);
        Task Create(Party entity);
    }
}
