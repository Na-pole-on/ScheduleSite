using DatabaseAccessLayer.Entities.Dates;
using DatabaseAccessLayer.Entities.Parties;
using DatabaseAccessLayer.Entities.Profiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Database
{
    public class AppDatabase: DbContext
    {
        DbSet<Student> Students { get; set; } = null!;
        DbSet<Teacher> Teachers { get; set; } = null!;
        DbSet<Role> Roles { get; set; } = null!;

        DbSet<Party> Parties { get; set; } = null!;
        DbSet<StudentParties> StudentParties { get; set; } = null!;

        DbSet<Day> Days { get; set; } = null!;
        DbSet<Event> Events { get; set; } = null!;

        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Profiles
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Parties)
                .WithOne(p => p.Teacher)
                .HasPrincipalKey(t => t.UserName)
                .HasForeignKey(p => p.NameTeacher);

            modelBuilder.Entity<Student>()
                .HasMany(t => t.Parties)
                .WithOne(p => p.Student)
                .HasPrincipalKey(t => t.UserName)
                .HasForeignKey(p => p.UserName);

            //Parties
            modelBuilder.Entity<Party>()
                .HasMany(p => p.Days)
                .WithOne(d => d.Party)
                .HasPrincipalKey(p => p.PartyIdentifier)
                .HasForeignKey(d => d.PartyIdentifier);

            modelBuilder.Entity<Party>()
                .HasMany(p => p.StudentParties)
                .WithOne(sp => sp.Party)
                .HasPrincipalKey(p => p.PartyIdentifier)
                .HasForeignKey(sp => sp.PartyIdentifier);

            //Dates
            modelBuilder.Entity<Day>()
                .HasMany(d => d.Events)
                .WithOne(h => h.Day)
                .HasPrincipalKey(d => d.Date)
                .HasForeignKey(h => h.Date);
        }
    }
}
