using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Db.Common.Models
{
    public class SqlServerDbContextOptionsStrategy:IDbContextOptionsStrategy
    {
        private readonly ConnectionSettings _connectionSettings;

        public SqlServerDbContextOptionsStrategy(ConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }

        public DbContextOptions Configure(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionSettings?.ConnectionString, sqlServerOptions =>
            {
                sqlServerOptions.CommandTimeout(_connectionSettings?.CommandTimeout ?? 60 * 60);
                sqlServerOptions.EnableRetryOnFailure(3);
            });
            return optionsBuilder.Options;
        }
    }
}
