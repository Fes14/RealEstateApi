using DataBase.Db.Common;
using DataBase.Db.Entities;
using DataBase.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Db
{
    /// <summary>
    /// Represents the interface for interacting with the company database.
    /// </summary>
    public interface ICompanyDataBase
    {
        /// <summary>
        /// Gets the repository for the RealEstate entity.
        /// </summary>
        IDbRepository<RealEstate> RealEstateRepository { get; }

        /// <summary>
        /// Gets the repository for the RealEstateType entity.
        /// </summary>
        IDbRepository<RealEstateType> RealEstateTypeRepository { get; }

        /// <summary>
        /// Gets the repository for the Developer entity.
        /// </summary>
        IDbRepository<Developer> DeveloperRepository { get; }

        /// <summary>
        /// Gets the repository for the Address entity.
        /// </summary>
        IDbRepository<Address> AddressRepository { get; }

        /// <summary>
        /// Saves changes made to the database.
        /// </summary>
        void SaveChanges();
    }
}
