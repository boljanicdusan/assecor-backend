using Assecor.Core.Colors;
using Assecor.Core.Persons;
using AutoMapper;

namespace Assecor.CSV.Mappings
{
    public class AssecorCsvMappingProfile : Profile
    {
        public AssecorCsvMappingProfile()
        {
            // Domain to DTO
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => DefaultColors.GetColorNameById(src.ColorId)))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => PersonDto.GetZipCodeFromAddress(src.Address)))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => PersonDto.GetCityFromAddress(src.Address)));

            // DTO to Domain
            CreateMap<PersonDto, Person>()
                .ForMember(dest => dest.ColorId, opt => opt.MapFrom(src => DefaultColors.GetColorIdByName(src.Color)))
                .ForMember(dest => dest.Color, opt => opt.Ignore())
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => PersonDto.GetAddress(src.ZipCode, src.City)));

        }
    }
}