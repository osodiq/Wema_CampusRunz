using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wema.CampusRunz.Core.Interfaces
{
    public class Repository1<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext db = null;
        private DbSet<T> table = null;

        //public Repository()
        //{
        //    this.db = new ApplicationDbContext();
        //    table = db.Set<T>();
        //}

        public Repository1(ApplicationDbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }


        public IQueryable<T> GetAll()
        {
            return table;
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        IQueryable<T> IRepository<T>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
