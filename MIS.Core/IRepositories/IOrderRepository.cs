using MIS.Core.Dtos;

namespace MIS.Core.IRepositories
{
    public interface IOrderRepository
    {
        List<OrderDto> GetAll();

        OrderDto? GetById(int id);

        List<OrderDto> GetByUserId(int userId);

        OrderDto Add(OrderDto dto);

        //bool Update(int id, OrderDto dto);

        bool Delete(int id);

        bool Exists(int id);
    }
}
