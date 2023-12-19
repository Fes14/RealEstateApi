using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Db.Common
{
    public abstract class DbRepository<T> : IDbRepository<T> where T : class
    {
        protected abstract DbSet<T> GetDbSet();

        public void Add(T entity)
        {
            GetDbSet().Add(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                GetDbSet().Remove(entity);
            }
        }

        public IQueryable<T> GetAll()
        {
            return GetDbSet();
        }
        public IQueryable<T> GetReadOnlyAll()
        {
            return GetDbSet().AsNoTracking();
        }

        public T? GetById(int id)
        {
            return GetDbSet().Find(id);
        }

        public T Update(T entity)
        {
           return GetDbSet().Update(entity).Entity;
        }
    }

}
