using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Db.Common
{
    public interface IDbRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetReadOnlyAll();
        T GetById(int id);
        void Add(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
