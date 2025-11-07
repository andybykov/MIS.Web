using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.IRepositories;
using MIS.Core.MappingProfiles;
using MIS.Core.OutputModels;

namespace MIS.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        private Mapper _mapper;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

            // Создаем MapperConfiguration и передаем OrderMappingProfile
            MapperConfiguration configuration = new MapperConfiguration((cfg =>
            {
                cfg.AddProfile(new OrderMappingProfile());
            }), new LoggerFactory());

            _mapper = new Mapper(configuration);
        }

        public List<OrderOutputModel> GetAll()
        {
            var dto = _orderRepository.GetAll();
            var result = _mapper.Map<List<OrderOutputModel>>(dto);
            return result;
        }

        public OrderOutputModel GetById(int id)
        {
            var dto = _orderRepository.GetById(id);
            var result = _mapper.Map<OrderOutputModel>(dto);
            return result;
        }

        public List<OrderOutputModel> GetByUserId(int userId)
        {
            var dto = _orderRepository.GetByUserId(userId);
            var result = _mapper.Map<List<OrderOutputModel>>(dto);
            return result;
        }

        public OrderOutputModel Add(OrderInputModel im)
        {
            var dto = _mapper.Map<OrderDto>(im);
            var result = _orderRepository.Add(dto);
            return _mapper.Map<OrderOutputModel>(result);
        }

        //public bool Update(int id, OrderInputModel im)
        //{
        //    var dto = _mapper.Map<OrderDto>(im);
        //    dto.Id = id; // Убедимся, что ID установлен
        //    return _orderRepository.Update(id, dto);
        //}

        public bool Delete(int id) => _orderRepository.Delete(id);

        public bool Exists(int id) => _orderRepository.Exists(id);
    }
}