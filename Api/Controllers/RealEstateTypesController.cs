using Api.Sevices;
using BusinessLogic.RealEstateService;
using BusinessLogic.RealEstateTypeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateTypesController : ControllerBase
    {
        private readonly IRealEstateTypeService _realEstateTypeService;

        public RealEstateTypesController(IRealEstateTypeService realEstateTypeService)
        {
            _realEstateTypeService = realEstateTypeService;
        }


        /// <summary>
        /// Получает все типы недвижимости
        /// </summary>
        /// <returns>Вернет список объектов типов недвижимости</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_realEstateTypeService.GetTypes());
        }
    }
}
