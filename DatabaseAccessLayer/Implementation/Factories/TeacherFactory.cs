using DatabaseAccessLayer.Database;
using DatabaseAccessLayer.Entities.Profiles;
using DatabaseAccessLayer.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Implementation.Factories
{
    internal class TeacherFactory: Factory<Teacher>
    {
        public TeacherFactory(AppDatabase db) : base(db) { }

        public override IEnumerable<Teacher>? GetAll() => db.Teachers
            .Include(t => t.Role)
            .Include(t => t.Parties);

        public override async Task<Teacher?> GetById(string id) => await db.Teachers
            .Include(t => t.Role)
            .Include(t => t.Parties)
            .FirstAsync(t => t.Id == id);

        public override async Task<Teacher?> GetByName(string name) => await db.Teachers
            .Include(t => t.Role)
            .Include(t => t.Parties)
            .FirstAsync(t => t.UserName == name);

        public override async Task<Teacher?> GetByEmail(string email) => await db.Teachers
            .Include(t => t.Role)
            .Include(t => t.Parties)
            .FirstAsync(t => t.Email == email);

        public override async Task Create(Teacher entity) => await db.Teachers
            .AddAsync(entity);
    }
}
