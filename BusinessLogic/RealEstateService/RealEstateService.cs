using BusinessLogic.Properties;
using BusinessLogic.RealEstateService.Dto;
using DataBase.Db;
using DataBase.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BusinessLogic.RealEstateService
{
    public class RealEstateService : IRealEstateService
    {
        private readonly ICompanyDataBase _db;

        public RealEstateService(ICompanyDataBase db)
        {
            _db = db;
        }
        public RealEstateDto Add(RealEstateDto realEstate)
        {
            if (realEstate == null)
            {
                throw new Exception(Resources.ParamNotSet);
            }
            var realEstateType = _db.RealEstateTypeRepository.GetReadOnlyAll().FirstOrDefault(x => x.Name.ToLower() == realEstate.Type.ToLower());

            if (realEstateType == null)
            {
                throw new Exception(string.Format(Resources.RealEstateTypeNotExistTemplate, realEstate.Type));
            }
            var developer = _db.DeveloperRepository.GetReadOnlyAll().FirstOrDefault(x => x.DeveloperName.ToLower() == realEstate.Developer.ToLower());
            if (developer == null)
            {
                throw new Exception(string.Format(Resources.DeveloperNotExistTemplate, realEstate.Developer));
            }
            if (realEstate.Address != null)
            {
                var address = _db.AddressRepository.GetReadOnlyAll().FirstOrDefault(x => x.House.ToLower() == realEstate.Address.House.ToLower()
                && x.Street.ToLower() == realEstate.Address.Street.ToLower()
                && x.City.ToLower() == realEstate.Address.City.ToLower()
                );
                if (address != null)
                {
                    throw new Exception(Resources.AddressAlreadyExist);
                }
            }


            var model = new RealEstate()
            {
                Description = realEstate.Description,
                Name = realEstate.Name,
                TypeId = realEstateType.RealEstateTypeId,
                Price = realEstate.Price,
                Square = realEstate.Square,
                DeveloperId = developer.DeveloperId,
                RoomsCount = realEstate?.RoomsCount ?? 0,
                Address = realEstate.Address != null ? new Address()
                {
                    City = realEstate.Address.City,
                    Street = realEstate.Address.Street,
                    House = realEstate.Address.House,
                } : null

            };
            _db.RealEstateRepository.Add(model);
            _db.SaveChanges();
            return GetById(model.RealEstateId);
        }

        public IEnumerable<RealEstateDto> GetAll()
        {
            return _db.RealEstateRepository.GetReadOnlyAll().Include(x => x.Type).Include(x => x.Developer).Include(x => x.Address).Select(BuildRealEstateDtoFromEntity);
        }

        public RealEstateDto GetById(int id)
        {
            var searchItem = _db.RealEstateRepository.GetById(id);
            if (searchItem != null)
            {
                searchItem.Type = _db.RealEstateTypeRepository.GetById(searchItem.TypeId);
                searchItem.Developer = _db.DeveloperRepository.GetById(searchItem.DeveloperId);
                searchItem.Address = _db.AddressRepository.GetById(searchItem.AddressId ?? 0);
                return BuildRealEstateDtoFromEntity(searchItem);
            }
            else
            {
                throw new Exception(string.Format(Resources.RealEstateNotExistTemplate, id));
            }
        }

        public RealEstateDto Update(RealEstateDto realEstate)
        {
            var searchItem = _db.RealEstateRepository.GetReadOnlyAll().Include(x => x.Address).FirstOrDefault(x => x.RealEstateId == realEstate.Id);
            if (searchItem != null)
            {
                if (realEstate == null)
                {
                    throw new Exception(Resources.ParamNotSet);
                }
                var realEstateType = _db.RealEstateTypeRepository.GetReadOnlyAll().FirstOrDefault(x => x.Name.ToLower() == realEstate.Type.ToLower());

                if (realEstateType == null)
                {
                    throw new Exception(string.Format(Resources.RealEstateTypeNotExistTemplate, realEstate.Type));
                }
                var developer = _db.DeveloperRepository.GetReadOnlyAll().FirstOrDefault(x => x.DeveloperName.ToLower() == realEstate.Developer.ToLower());
                if (developer == null)
                {
                    throw new Exception(string.Format(Resources.DeveloperNotExistTemplate, realEstate.Developer));
                }

                if (realEstate.Address != null)
                {
                    var address = _db.AddressRepository.GetReadOnlyAll().FirstOrDefault(x => x.House.ToLower() == realEstate.Address.House.ToLower()
                    && x.Street.ToLower() == realEstate.Address.Street.ToLower()
                    && x.City.ToLower() == realEstate.Address.City.ToLower()
                    && searchItem.AddressId != x.Id
                    );
                    if (address != null)
                    {
                        throw new Exception(Resources.AddressAlreadyExist);
                    }
                }

                searchItem.Description = realEstate.Description;
                searchItem.Name = realEstate.Name;
                searchItem.Description = realEstate.Description;
                searchItem.Name = realEstate.Name;
                searchItem.Type = realEstateType;
                searchItem.Price = realEstate.Price;
                searchItem.Square = realEstate.Square;
                searchItem.Developer = developer;
                searchItem.RoomsCount = realEstate?.RoomsCount ?? 0;
                searchItem.Address = realEstate.Address != null ? new Address()
                {
                    City = realEstate.Address.City,
                    Street = realEstate.Address.Street,
                    House = realEstate.Address.House,
                } : null;
                _db.RealEstateRepository.Update(searchItem);
                _db.SaveChanges();
                return GetById(searchItem.RealEstateId);
            }
            else
            {
                throw new Exception(string.Format(Resources.RealEstateNotExistTemplate, realEstate.Id));
            }
        }

        private RealEstateDto BuildRealEstateDtoFromEntity(RealEstate entity)
        {
            return new RealEstateDto()
            {
                Id = entity.RealEstateId,
                Name = entity.Name,
                Description = entity.Description,
                Type = entity.Type?.Name ?? string.Empty,
                Price = entity.Price,
                Square = entity.Square,
                Developer = entity.Developer?.DeveloperName ?? string.Empty,
                Address = BuildAddressDtoFromEntity(entity.Address),
                RoomsCount = entity.RoomsCount,

            };
        }

        private AddressDto BuildAddressDtoFromEntity(Address? entity)
        {
            return new AddressDto()
            {
                Street = entity?.Street ?? "",
                City = entity?.City ?? "",
                House = entity?.House ?? "",
                MetroStation = entity?.MetroStation ?? "",
            };
        }
    }
}
