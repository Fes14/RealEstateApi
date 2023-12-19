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
    public class RealEstateRepository : DbRepository<RealEstate>
    {
        private readonly CompanyDataBaseContext _dbContext;
        public RealEstateRepository(CompanyDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override DbSet<RealEstate> GetDbSet()
        {
            return _dbContext.RealEstates;
        }
    }
}
