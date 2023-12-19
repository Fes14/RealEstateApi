using Api.Sevices;
using BusinessLogic.DeveloperService;
using BusinessLogic.RealEstateService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IDeveloperService _developerService;

        public DevelopersController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }


        /// /// <summary>
        /// Получает всех застройщиков
        /// </summary>
        /// <returns>Вернет список объектов застройщиков</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_developerService.GetDevelopers());
        }
    }
}
