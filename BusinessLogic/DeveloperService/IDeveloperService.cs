using BusinessLogic.DeveloperService.Dto;
using BusinessLogic.RealEstateTypeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DeveloperService
{
    public interface IDeveloperService
    {
        List<DeveloperDto> GetDevelopers();
    }
}
