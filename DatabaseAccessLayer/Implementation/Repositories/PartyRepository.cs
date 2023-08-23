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

        public async Task Add(Student entity)
        {
            Party? party = await GetByPartyId(entity.PartyIdentifier);

            if (party is not null)
                entity.Party = party;
        }

        public async Task Remove(Student entity)
        {
            Party? party = await GetByPartyId("Empty");

            if (party is not null)
                entity.Party = party;
        }

        public async Task Create(Party entity) => await db.Parties.AddAsync(entity);
    }
}
