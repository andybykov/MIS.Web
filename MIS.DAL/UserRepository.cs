using MIS.Core;
using MIS.Core.Dtos;
using MIS.Core.IRepositories;

namespace MIS.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext) => _dataContext = dataContext;

        public List<UserDto> GetAll()
        {
            var result = _dataContext.Users.OrderBy(p => p.Id)
            .Where(i => i.IsRemoved == false)
            .ToList();
            return result;
        }          

        public List<UserDto> GetAllWithRemoved()
        {
            var result = _dataContext.Users.OrderBy(p => p.Id)
            .ToList();
            return result;
        }
            

        public List<UserDto> GetRemoved()
        {
            var result = _dataContext.Users.OrderBy(p => p.Id)
            .Where(i => i.IsRemoved == true)
            .ToList();
            return result;
        }

        public UserDto GetById(int id)
        {
            if (Exists(id))
            {
                return _dataContext.Users.Find(id);
            }
            return null;
            
        }            

        public UserDto Add(UserDto dto)
        {
            _dataContext.Users.Add(dto);
            _dataContext.SaveChanges();
            return dto;
        }

        public bool Update(int id, UserDto dto)
        {
            var cur = GetById(id);
            if (cur is null)
            {
                return false;
            }
            _dataContext.Entry(cur).CurrentValues.SetValues(dto);
            _dataContext.SaveChanges();
            return true;
        }

        // Удаляем по-настоящему
        public bool Delete(int id)
        {
            var cur = GetById(id);
            if (cur is null)
            {
                return false;
            }
            _dataContext.Users.Remove(cur);
            _dataContext.SaveChanges();
            return true;
        }

        // Установка флага IsRemoved = true
        public bool Remove(int id)
        {
            var cur = GetById(id);
            if (cur is null)
            {
                return false;
            }                
            cur.IsRemoved = true;
            _dataContext.Users.Update(cur);
            _dataContext.SaveChanges();
            return true;
        }

        public bool Exists(int id) => _dataContext.Users.Any(p => p.Id == id);
        
    }
}
