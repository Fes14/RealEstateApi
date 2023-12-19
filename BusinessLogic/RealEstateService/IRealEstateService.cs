using BusinessLogic.RealEstateService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BusinessLogic.RealEstateService
{
    public interface IRealEstateService
    {
        IEnumerable<RealEstateDto> GetAll();
        RealEstateDto GetById(int id);
        RealEstateDto Add(RealEstateDto realEstate);
        RealEstateDto Update(RealEstateDto realEstate);
    }
}
