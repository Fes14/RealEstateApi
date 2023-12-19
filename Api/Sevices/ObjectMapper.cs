using Api.ViewModels;
using AutoMapper;
using BusinessLogic.RealEstateService.Dto;
using System.Reflection.Metadata;

namespace Api.Sevices
{
    public class ObjectMapper : IRealStateMapper
    {
        private readonly IMapper _mapper;

        public ObjectMapper()
        {
            MapperConfiguration config = Init();

            config.AssertConfigurationIsValid();

            _mapper = config.CreateMapper();
        }
        public TDest Map<TDest>(object src)
        {
            return _mapper.Map<TDest>(src);
        }
        private MapperConfiguration Init()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RealEstateVm, RealEstateDto>();
                cfg.CreateMap<AddressVm, AddressDto>();

            });
        }
    }
}
