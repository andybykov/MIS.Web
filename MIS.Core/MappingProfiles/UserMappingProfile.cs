using AutoMapper;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.OutputModels;

namespace MIS.Core.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            // на вход 2 типа даннымх source, destination т.е. откуда и куда перекладыать
            CreateMap<UserDto, UserOutputModel>()
                .ForMember(
                dest => dest.FullName, // куда
                opt => opt.MapFrom(
                        src => $"{src.FirstName}" +
                               $" {src.LastName}"
                                   )); // откуда; 

            // Маппинг из InputModel в DTO
            CreateMap<UserInputModel, UserDto>()
                .ForMember(dest => dest.RegistrationDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow)) // Всегда UTC
                .ForMember(dest => dest.Role,
                    opt => opt.MapFrom(src => UserRole.Client))
                .ForMember(dest => dest.IsRemoved,
                    opt => opt.MapFrom(src => src.IsRemoved))
                .ForMember(dest => dest.DateOfBirth,
                    opt => opt.MapFrom(src => src.DateOfBirth.HasValue
                        ? DateTime.SpecifyKind(src.DateOfBirth.Value.Date, DateTimeKind.Utc)
                        : (DateTime?)null)); // Конвертируем в UTC

            // OutputModel в DTO
            CreateMap<UserOutputModel, UserDto>()
           .ForMember(dest => dest.FirstName,
               opt => opt.MapFrom(src => GetFirstName(src.FullName)))
           .ForMember(dest => dest.LastName,
               opt => opt.MapFrom(src => GetLastName(src.FullName)))
           .ForMember(dest => dest.DateOfBirth,
               opt => opt.MapFrom(src => DateTime.SpecifyKind(src.DateOfBirth, DateTimeKind.Utc)));
        }
            #region GetNames
            //  Метод для извлечения имени
        private string GetFirstName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return string.Empty;

            var parts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return parts.Length > 0 ? parts[0] : string.Empty;
        }

        //  Метод для извлечения фамилии
        private string GetLastName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return string.Empty;

            var parts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1)
                return string.Empty; // Если только одно слово - фамилии нет
            else
                return string.Join(" ", parts.Skip(1)); // Все остальные слова - фамилия
        }

        #endregion
    }

}
    
