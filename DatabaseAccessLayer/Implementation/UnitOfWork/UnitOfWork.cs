using DatabaseAccessLayer.Database;
using DatabaseAccessLayer.Entities.Profiles;
using DatabaseAccessLayer.Factories;
using DatabaseAccessLayer.Implementation.Factories;
using DatabaseAccessLayer.Implementation.Repositories;
using DatabaseAccessLayer.Implementation.SignIn;
using DatabaseAccessLayer.Interfaces.Repositories;
using DatabaseAccessLayer.Interfaces.SignIn;
using DatabaseAccessLayer.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Implementation.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private AppDatabase db;

        private StudentFactory? studentFactory;
        private TeacherFactory? teacherFactory;

        private SignInManager? signInManager;

        private RoleRepository? roleRepository;

        private DateRepository? dateRepository;

        private PartyRepository? partyRepository;


        private IHttpContextAccessor context;
        private bool disposed = false;


        public UnitOfWork(AppDatabase db, IHttpContextAccessor context)
        {
            this.db = db;
            this.context = context;
        }


        //Factories
        public Factory<Student> Students
        {
            get
            {
                if (studentFactory is null)
                    studentFactory = new StudentFactory(db);

                return studentFactory;
            }
        }
        public Factory<Teacher> Teachers
        {
            get
            {
                if (teacherFactory is null)
                    teacherFactory = new TeacherFactory(db);

                return teacherFactory;
            }
        }

        //SignIn
        public ISignIn<User> SignInManager
        {
            get
            {
                if (signInManager is null)
                    signInManager = new SignInManager(db, context);

                return signInManager;
            }
        }

        //Roles
        public IRoleRepository Roles
        {
            get
            {
                if (roleRepository is null)
                    roleRepository = new RoleRepository(db);

                return roleRepository;
            }
        }

        //Dates
        public IDateRepository Dates
        {
            get
            {
                if (dateRepository is null)
                    dateRepository = new DateRepository(db);

                return dateRepository;
            }
        }

        //Parties
        public IPartyRepository Parties
        {
            get
            {
                if (partyRepository is null)
                    partyRepository = new PartyRepository(db);

                return partyRepository;
            }
        }

        //Cleaner
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                db.Dispose();
                disposed = true;
            }
        }

        //Save database
        public async Task SaveAsync() => await db.SaveChangesAsync();

    }
}
