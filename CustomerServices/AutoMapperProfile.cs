using AutoMapper;
using CustomerServices.DataAccessLayer.Models;

namespace CustomerServices
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, ListCustomersResult>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(source => source.Address))
            .ForMember(dest => dest.VatIdentyficationNumber, opt => opt.MapFrom(source => source.VatIdentyficationNumber))
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(source => source.CreationDate));

        }
    }
}
