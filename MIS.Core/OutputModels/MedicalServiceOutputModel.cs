using MIS.Core.Dtos;

namespace MIS.Core.OutputModels
{
    public class MedicalServiceOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool IsRemoved { get; set; } //флаг удаления

        // Список заказов, в которых есть эта услуга
        public List<OrderDto>? Orders { get; set; }

    }
}
