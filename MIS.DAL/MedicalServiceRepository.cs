using Microsoft.EntityFrameworkCore;
using MIS.Core;
using MIS.Core.Dtos;
using MIS.Web.IRepositories;

namespace MIS.DAL
{
    public class MedicalServiceRepository : IMedicalServiceRepository
    {
        private DataContext? _dataContext; // дает возможность обращаться к данным

        public MedicalServiceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Получить все
        public List<MedicalServiceDto> GetAll()
        {
            var result = _dataContext.MedicalServices
                //.Include(r=> r.IsRemoved)
                .Where(ms => !ms.IsRemoved)
                .OrderBy(ms => ms.Name) // сортируем по Id
                .ToList();
            return result;
        }

        //GetAllWithRemoved()
        public List<MedicalServiceDto> GetAllWithRemoved()
        {
            var result = _dataContext.MedicalServices
                .OrderBy(ms => ms.Name) // сортируем по Id
                .ToList();
            return result;
        }

        // Добавление новой услуги
        public MedicalServiceDto Add(MedicalServiceDto dto)
        {
            _dataContext.MedicalServices.Add(dto);
            _dataContext.SaveChanges();
            return dto;
        }

        // Получить по Id
        public MedicalServiceDto GetById(int id)
        {
            var result = _dataContext.MedicalServices.Find(id);
            return result;
        }
       
        // Обновить   
        public bool Update(int id, MedicalServiceDto dto)
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

        // Удалить
        public bool Delete(int id)
        {
            var cur = GetById(id);
            if (cur is null)
            {
                return false;
            }
            else 
            {
                _dataContext.MedicalServices.Remove(cur);
                _dataContext.SaveChanges();
                return true;
            }
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
            _dataContext.MedicalServices.Update(cur);
            _dataContext.SaveChanges();
            return true;
        }

        // Проверка на существование записи
        //public bool Exist(int id)
        //{
        //    var tmp = _dataContext.MedicalServices.Find(id);
        //    var result = (tmp != null) ? true : false;
        //    return result;
        //}
        // Проверка на существование записи через предикат
        public bool Exists(int id) => _dataContext.MedicalServices.Any(d => d.Id == id); // проверяет, есть ли хотя бы один элемент, удовлетворяющий предикату
    }
}
