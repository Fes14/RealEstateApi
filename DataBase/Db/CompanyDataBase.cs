using DataBase.Db.Common;
using DataBase.Db.Common.Models;
using DataBase.Db.Entities;
using DataBase.Db.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Db
{
    public class CompanyDataBase : ICompanyDataBase
    {
        private CompanyDataBaseContext _dbContext;
        private ConnectionSettings _connectionSettings;

        private IDbRepository<RealEstate> _realEstateRepository;
        private IDbRepository<RealEstateType> _realEstateTypeRepository;
        private IDbRepository<Developer> _developerRepository;
        private IDbRepository<Address> _addressRepository;
        public CompanyDataBase(ConnectionSettings settings)
        {
            _connectionSettings = settings;
            Init();
        }
        public IDbRepository<RealEstate> RealEstateRepository => Init()._realEstateRepository;

        public IDbRepository<RealEstateType> RealEstateTypeRepository => Init()._realEstateTypeRepository;

        public IDbRepository<Developer> DeveloperRepository => Init()._developerRepository;

        public IDbRepository<Address> AddressRepository => Init()._addressRepository;

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        private CompanyDataBase Init()
        {
            if (_dbContext == null)
            {
                _dbContext = new CompanyDataBaseContext(BuildOptions());
                _realEstateRepository = new RealEstateRepository(_dbContext);
                _realEstateTypeRepository = new RealEstateTypeRepository(_dbContext);
                _developerRepository = new DeveloperRepository(_dbContext);
                _addressRepository = new AddressRepository(_dbContext);
            }
            return this;
        }

        private DbContextOptions BuildOptions()
        {

            IDbContextOptionsStrategy sqlServerStrategy = _connectionSettings.InMemory ? new InMemoryDbContextOptionsStrategy() : new SqlServerDbContextOptionsStrategy(_connectionSettings);

            return sqlServerStrategy.Configure(new DbContextOptionsBuilder<CompanyDataBaseContext>());
        }
    }
}
