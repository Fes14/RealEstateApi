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
    public class AddressRepository : DbRepository<Address>
    {
        private readonly CompanyDataBaseContext _dbContext;
        public AddressRepository(CompanyDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override DbSet<Address> GetDbSet()
        {
            return _dbContext.Addresses;
        }
    }
}
