using DatabaseAccessLayer.Database;
using DatabaseAccessLayer.Entities.Parties;
using DatabaseAccessLayer.Entities.Profiles;
using DatabaseAccessLayer.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Implementation.Repositories
{
    internal class PartyRepository : IPartyRepository
    {
        public AppDatabase db;

        public PartyRepository(AppDatabase db) => this.db = db;

        public IEnumerable<Party> GetAll() => db.Parties
            .Include(p => p.StudentParties)
            .Include(p => p.Students)
            .Include(p => p.Days);

        public Task<Party?> GetById(string id) => db.Parties
            .Include(p => p.StudentParties)
            .Include(p => p.Students)
            .Include(p => p.Days)
            .FirstOrDefaultAsync(p => p.Id == id);

        public Task<Party?> GetByPartyId(string partyId) => db.Parties
            .Include(p => p.StudentParties)
            .Include(p => p.Students)
            .Include(p => p.Days)
            .FirstOrDefaultAsync(p => p.PartyIdentifier == partyId);

        public async Task<bool> NotEnter(string studentId, string partyId)
        {
            Party? party = await db.Parties
                .FirstOrDefaultAsync(p => p.Id == partyId);

            if (party is not null)
                if (party.Students is not null)
                    return party.Students.Any(s => s.Id == studentId);

            return false;
        }

        public void Add(Student entity, Party party) => party.Students
            .Add(entity);

        public void Remove(Student entity, Party party) => party.Students
            .Remove(entity);

        public async Task Create(Party entity) => await db.Parties.AddAsync(entity);
    }
}
