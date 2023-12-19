using BusinessLogic.RealEstateTypeService.Dto;
using DataBase.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.RealEstateTypeService
{
    public class RealEstateTypeService : IRealEstateTypeService
    {

        private readonly ICompanyDataBase _db;

        public RealEstateTypeService(ICompanyDataBase db)
        {
            _db = db;
        }

        List<RealEstateTypeDto> IRealEstateTypeService.GetTypes()
        {
            return _db.RealEstateTypeRepository.GetReadOnlyAll().Select(x => new RealEstateTypeDto
            {
                Name = x.Name,
                Id = x.RealEstateTypeId
            }).ToList();
        }
    }
}
