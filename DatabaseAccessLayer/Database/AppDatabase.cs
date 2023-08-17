using DatabaseAccessLayer.Converter;
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
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Admin> Privileged { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        public DbSet<Party> Parties { get; set; } = null!;
        public DbSet<StudentParties> StudentParties { get; set; } = null!;

        public DbSet<Day> Days { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;

        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();

            if (this.Roles.Count() == 0)
                DefaultRoles();

            if (this.Privileged.Count() == 0)
                DefaultUser();

            if (this.Parties.Count() == 0)
                DefaultParty();
        }

        private void DefaultRoles()
        {
            Role student = new Role { Name = "Student", NormalizedName = "STUDENT" };
            Role teacher = new Role { Name = "Teacher", NormalizedName = "TEACHER" };
            Role admin = new Role { Name = "Admin", NormalizedName = "ADMIN" };

            Roles.AddRange(student, teacher, admin);
            this.SaveChanges();
        }
        private void DefaultUser()
        {
            Admin admin = new Admin
            {
                UserName = "Juiko Mathew",
                NormalizedUserName = "Juiko Mathew".ToUpper(),
                Email = "juikomathew@gmail.com",
                NormalizedEmail = "juikomathew@gmail.com".ToUpper(),
                PhoneNumber = "+375(29)393-17-60",
                PhoneNumberConfirmed = true,
                DateOfBirth = new DateOnly(2002, 5, 30),
                Role = this.Roles.FirstOrDefault(r => r.Name == "Admin"),
                LockoutEnabled = false
            };

            Privileged.Add(admin);
            this.SaveChanges();
        }
        private void DefaultParty()
        {
            Party party = new Party
            {
                Name = "null",
                Description = "null",
                PartyIdentifier = "null"
            };

            Parties.Add(party);
            this.SaveChanges();
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

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            configurationBuilder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>()
                .HaveColumnType("time");
        }
    }
}
