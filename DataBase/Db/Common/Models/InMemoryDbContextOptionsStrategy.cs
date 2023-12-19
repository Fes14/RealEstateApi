using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Db.Common.Models
{
    public class InMemoryDbContextOptionsStrategy : IDbContextOptionsStrategy
    {
        public DbContextOptions Configure(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDb");
            return optionsBuilder.Options;
        }
    }
}
