using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.Core;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.IRepositories;
using MIS.Core.MappingProfiles;
using MIS.Core.OutputModels;

namespace MIS.BLL
{

    public class UserManager
    {
        private IUserRepository _userRepository;
        private Mapper _mapper;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            // Создаем MapperConfiguration и передаем DoctorMapperProfile
            MapperConfiguration configuration = new MapperConfiguration((cfg =>
            {
                cfg.AddProfile(new UserMappingProfile());
            }), new LoggerFactory());

            _mapper = new Mapper(configuration);

        }

        // Логин по Email
        public UserOutputModel GetByLogin(string login)
        {
            var users = GetAll();
            return users.FirstOrDefault(u =>
                u.Email.Equals(login, StringComparison.OrdinalIgnoreCase));
        }


        // Аутентификация пользователя    
        public bool AuthUser(LoginModel lm)
        {
            var user = GetByLogin(lm.Login);
            if (user == null) return false;
            else return user.Password == lm.Password;
        }

        // Получить пользователя по идентификатору 
        public UserOutputModel GetAuthorizedUser(int userId)
        {
            if (!Exists(userId))
            {
                return null;
            }
            else
            {
                return GetById(userId);
            }
        }


        //  имеет ли пользователь  роль
        public bool HasRole(int userId, UserRole role)
        {
            var user = GetById(userId);
            return user?.Role == role;
        }

        // Получить всех пользователей с определенной ролью
        public List<UserOutputModel> GetUsersByRole(UserRole role)
        {
            var users = GetAll();
            return users.Where(u => u.Role == role).ToList();
        }

        public List<UserOutputModel> GetAllWithRemoved()
        {
            var dto = _userRepository.GetAllWithRemoved();
            var result = _mapper.Map<List<UserOutputModel>>(dto);
            return result;
        }

        public List<UserOutputModel> GetAll()
        {
            var dto = _userRepository.GetAll();
            var result = _mapper.Map<List<UserOutputModel>>(dto);
            return result;
        }

        public List<UserOutputModel> GetRemoved()
        {
            var dto = _userRepository.GetRemoved();
            var result = _mapper.Map<List<UserOutputModel>>(dto);
            return result;
        }

        public UserOutputModel GetById(int id)
        {
            var dto = _userRepository.GetById(id);
            var result = _mapper.Map<UserOutputModel>(dto);
            return result;
        }

        public UserOutputModel Add(UserInputModel im)
        {
            var dto = _mapper.Map<UserDto>(im);
            var result = _userRepository.Add(dto);
            return _mapper.Map<UserOutputModel>(result);
        }

        public bool Update(int id, UserOutputModel om)
        {
            var dto = _mapper.Map<UserDto>(om);
            var result = _userRepository.Update(id, dto);
            return true;
        }

        public bool Remove(int id) => _userRepository.Remove(id);

        public bool Delete(int id) => _userRepository.Delete(id);

        public bool Exists(int id) => _userRepository.Exists(id);


        public bool CheckEmailUnique(UserInputModel input, UserOutputModel output)
        {            
            if (input == null || output == null) return false;

            // Сравнение без учета регистра
            return string.Equals(input.Email, output.Email, StringComparison.OrdinalIgnoreCase);
        }

        public bool CheckPhoneUnique(UserInputModel input, UserOutputModel output)
        {
            if (input == null || output == null) return false;

            // Сравнение без учета регистра
            return string.Equals(input.PhoneNumber, output.PhoneNumber, StringComparison.OrdinalIgnoreCase);
        }

    }
}
