using Api.Sevices;
using Api.ViewModels;
using BusinessLogic.RealEstateService;
using BusinessLogic.RealEstateService.Dto;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstatesController : ControllerBase
    {
        private readonly IRealEstateService _realEstateService;
        private readonly IRealStateMapper _mapper;

        public RealEstatesController(IRealEstateService realEstateService, IRealStateMapper mapper)
        {
            _realEstateService = realEstateService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получает всю недвижимость
        /// </summary>
        /// <returns> Список недвижимостей</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_realEstateService.GetAll());
        }

        /// <summary>
        /// Получает недвижимость по орпделнному id
        /// </summary>
        /// /// <param name="id"></param>
        /// <returns>Вернет недвижимость по орпделнному id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_realEstateService.GetById(id));
        }

        /// <summary>
        /// Добавить новую недвижимость
        /// </summary>
        /// <param name="vm"></param>
        /// <returns>Вернет новую созданную недвижимость</returns>
        [HttpPost]
        public IActionResult Post([FromBody] RealEstateVm vm)
        {
            var dto = _mapper.Map<RealEstateDto>(vm);
            return new JsonResult(_realEstateService.Add(dto));
        }

        /// <summary>
        /// Обновить определную недвижимость
        /// </summary>
        /// /// <param name="vm"></param>
        /// <returns>Вернет обновленный объект недвижимости</returns>
        [HttpPut]
        public IActionResult Put([FromBody] RealEstateVm vm)
        {
            var dto = _mapper.Map<RealEstateDto>(vm);
            return new JsonResult(_realEstateService.Update(dto));
        }
    }
}
