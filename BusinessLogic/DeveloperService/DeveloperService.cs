using BusinessLogic.DeveloperService.Dto;
using BusinessLogic.RealEstateTypeService.Dto;
using DataBase.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DeveloperService
{
    public class DeveloperService : IDeveloperService
    {
        private readonly ICompanyDataBase _db;

        public DeveloperService(ICompanyDataBase db)
        {
            _db = db;
        }
        public List<DeveloperDto> GetDevelopers()
        {
            return _db.DeveloperRepository.GetReadOnlyAll().Select(x => new DeveloperDto
            {
                Name = x.DeveloperName,
                Id = x.DeveloperId
            }).ToList();
        }
    }
}
