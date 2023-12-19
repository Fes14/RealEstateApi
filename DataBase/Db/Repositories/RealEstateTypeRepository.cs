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
    public class RealEstateTypeRepository : DbRepository<RealEstateType>
    {
        private readonly CompanyDataBaseContext _context;
        public RealEstateTypeRepository(CompanyDataBaseContext context)
        {
            _context = context;
        }
        protected override DbSet<RealEstateType> GetDbSet()
        {
            return _context.RealEstateTypes;
        }
    }
}
