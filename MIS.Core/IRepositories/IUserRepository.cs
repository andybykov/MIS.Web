using MIS.Core.Dtos;

namespace MIS.Core.IRepositories
{
    public interface IUserRepository
    {
        List<UserDto> GetAll();

        List<UserDto> GetAllWithRemoved();

        List<UserDto> GetRemoved();

        UserDto? GetById(int id);

        UserDto Add(UserDto dto);

        bool Update(int id, UserDto dto);

        bool Delete(int id);

        bool Remove(int id);

        bool Exists(int id);
    }
}
