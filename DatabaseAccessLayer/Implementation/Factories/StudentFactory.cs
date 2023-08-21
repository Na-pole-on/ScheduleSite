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
    internal class StudentFactory: Factory<Student>
    {
        public StudentFactory(AppDatabase db) : base(db) { }

        public override IEnumerable<Student>? GetAll() => db.Students
            .Include(s => s.Role)
            .Include(s => s.Party);

        public override async Task<Student?> GetById(string id) => await db.Students
            .Include(s => s.Role)
            .Include(s => s.Party)
            .FirstAsync(s => s.Id == id);

        public override async Task<Student?> GetByName(string name) => await db.Students
            .Include(s => s.Role)
            .Include(s => s.Party)
            .FirstAsync(s => s.UserName == name);

        public override async Task<Student?> GetByEmail(string email) => await db.Students
            .Include(s => s.Role)
            .Include(s => s.Party)
            .FirstAsync(s => s.Email == email);

        public override async Task Create(Student entity) => await db.Students
            .AddAsync(entity);
    }
}
