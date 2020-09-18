using System;
using AutoMapper;
using Assecor.Core.Persons;

namespace Assecor.EF.Mappings
{
    public class AssecorEfMappingProfile : Profile
    {
        public AssecorEfMappingProfile()
        {
            // Domain to DTO
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.Name))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => PersonDto.GetZipCodeFromAddress(src.Address)))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => PersonDto.GetCityFromAddress(src.Address)));
                
            // DTO to Domain
            CreateMap<PersonDto, Person>()
                .ForMember(dest => dest.ColorId, opt => opt.Ignore())
                .ForMember(dest => dest.Color, opt => opt.Ignore())
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => PersonDto.GetAddress(src.ZipCode, src.City)));
        }
    }
}