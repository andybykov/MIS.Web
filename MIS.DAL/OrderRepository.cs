using Microsoft.EntityFrameworkCore;
using MIS.Core;
using MIS.Core.Dtos;
using MIS.Core.IRepositories;

namespace MIS.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext) => _dataContext = dataContext;

        public List<OrderDto> GetAll() =>
            _dataContext.Orders
                .Include(o => o.User)  
                .Include(o => o.MedicalService)  
                .OrderByDescending(o => o.Date)  
                .ToList();

        public OrderDto? GetById(int id) =>
            _dataContext.Orders
                .Include(o => o.User)
                .Include(o => o.MedicalService)
                .SingleOrDefault(o => o.Id == id);


        public List<OrderDto> GetByUserId(int userId) =>
            _dataContext.Orders
                .Include(o => o.User)
                .Include(o => o.MedicalService)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.Date)
                .ToList();

        public OrderDto Add(OrderDto dto)
        {            
            _dataContext.Orders.Add(dto);
            _dataContext.SaveChanges();
            return dto;
        }

        //public bool Update(int id, OrderDto dto)
        //{
        //    var current = _dataContext.Orders.Find(id);
        //    if (current is null) return false;

        //    current.Date = dto.Date;
        //    current.OrderStatus = dto.OrderStatus;
        //    current.TotalAmount = dto.TotalAmount;
        //    current.UserId = dto.UserId;
        //    current.ServiceId = dto.ServiceId;

        //    _dataContext.SaveChanges();
        //    return true;
        //}

        public bool Delete(int id)
        {
            var current = _dataContext.Orders.Find(id);
            if (current is null) return false;
            _dataContext.Orders.Remove(current);
            _dataContext.SaveChanges();
            return true;
        }

        public bool Exists(int id) => _dataContext.Orders.Any(o => o.Id == id);
    }
}