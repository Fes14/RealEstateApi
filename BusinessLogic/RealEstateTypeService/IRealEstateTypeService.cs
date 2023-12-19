using BusinessLogic.RealEstateTypeService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.RealEstateTypeService
{
    public interface IRealEstateTypeService
    {
        List<RealEstateTypeDto> GetTypes();
    }
}
