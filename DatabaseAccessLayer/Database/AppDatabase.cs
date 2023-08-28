using DatabaseAccessLayer.Comparer;
using DatabaseAccessLayer.Entities.Dates;
using DatabaseAccessLayer.Entities.Parties;
using DatabaseAccessLayer.Entities.Profiles;
using DatabaseAccessLayer.Mapping;
using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<Party>()
                .HasMany(p => p.Students)
                .WithMany(s => s.Parties)
                .UsingEntity<StudentParties>(
                    s => s
                        .HasOne(p => p.Student)
                        .WithMany(sp => sp.StudentParties)
                        .HasPrincipalKey(p => p.UserName)
                        .HasForeignKey(sp => sp.StudentName),

                    s => s
                    .HasOne(p => p.Party)
                    .WithMany(sp => sp.StudentParties)
                    .HasPrincipalKey(p => p.PartyIdentifier)
                    .HasForeignKey(sp => sp.PartyIdentifier),

                    s =>
                    {
                        s.ToTable("StudentParties");
                    }
                );

            //Dates
            modelBuilder.Entity<Day>()
                .HasMany(d => d.Events)
                .WithOne(h => h.Day)
                .HasPrincipalKey(d => d.Date)
                .HasForeignKey(h => h.Date);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<DateOnly>()
            .HaveConversion<DateOnlyToDate, DateOnlyComparer>()
            .HaveColumnType("date");

            configurationBuilder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyToTime, TimeOnlyComparer>();
        }
    }
}
