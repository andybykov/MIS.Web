using System.ComponentModel.DataAnnotations;

namespace MIS.Core.Dtos
{
    // Медицинские "услуги"
    public class MedicalServiceDto
    {
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; } = 100; // Базовая цена        

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty; // описание. например какая нужна подготовкаа
                                                            
        public bool IsRemoved { get; set; } = false; //флаг удаления 

        // Список заказов, в которых есть эта услуга
        public List<OrderDto>? Orders{ get; set; }     
    }
}
