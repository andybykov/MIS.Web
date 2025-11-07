using AutoMapper;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.OutputModels;

namespace MIS.Core.MappingProfiles
{
    public class MedicalServiceMappingProfile : Profile
    {
        public MedicalServiceMappingProfile() 
        {
            CreateMap<MedicalServiceDto, MedicalServiceOutputModel>();
            CreateMap<MedicalServiceOutputModel, MedicalServiceDto>();
            CreateMap<MedicalServiceInputModel, MedicalServiceDto>();
        }
    }
}
