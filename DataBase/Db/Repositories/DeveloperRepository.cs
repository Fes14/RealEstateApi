using DataBase.Db.Common;
using DataBase.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Db.Repositories
{
    public class DeveloperRepository : DbRepository<Developer>
    {
        private readonly CompanyDataBaseContext _dbContext;
        public DeveloperRepository(CompanyDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override DbSet<Developer> GetDbSet()
        {
            return _dbContext.Developers;
        }
    }
}
