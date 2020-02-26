using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wema.CampusRunz.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
        void Dispose();
    }
}
