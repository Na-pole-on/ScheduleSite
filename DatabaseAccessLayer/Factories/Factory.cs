using DatabaseAccessLayer.Database;
using DatabaseAccessLayer.Entities.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Factories
{
    public abstract class Factory<T>
        where T : User
    {
        protected AppDatabase db;

        public Factory(AppDatabase db) => this.db = db;

        public abstract IEnumerable<T>? GetAll();
        public abstract Task<T?> GetById(string id);
        public abstract Task<T?> GetByName(string name);
        public abstract Task<T?> GetByEmail(string email);
        public abstract Task Create(T entity);

    }
}
