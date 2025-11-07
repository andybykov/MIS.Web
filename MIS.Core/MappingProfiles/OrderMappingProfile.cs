using AutoMapper;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.OutputModels;

namespace MIS.Core.MappingProfiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            {
                CreateMap<OrderDto, OrderOutputModel>();
                //.ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                //.ForMember(dest => dest.MedicalServices, opt => opt.MapFrom(src => src.MedicalServices));

                // InputModel в DTO
                CreateMap<OrderInputModel, OrderDto>()
                    .ForMember(dest => dest.Date,
                        opt => opt.MapFrom(src => DateTime.UtcNow)); // UTC
                    //.ForMember(dest => dest.Users, opt => opt.Ignore()) // Игнорируем навигационные свойства
                    //.ForMember(dest => dest.MedicalServices, opt => opt.Ignore());
            }
        }
    }
}
