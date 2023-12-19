using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Db.Common.Models
{
    public interface IDbContextOptionsStrategy
    {
        DbContextOptions Configure(DbContextOptionsBuilder optionsBuilder);
    }
}
