using System.ComponentModel.DataAnnotations;

namespace MIS.Core.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        // Дата и время создания заказа
        public DateTime Date { get; set; } = DateTime.Now;

        // Статус заказа       
        [Required]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.New;

        // Общая сумма заказа 
        public decimal TotalAmount { get; set; } = decimal.Zero;

        // FK
        [Required]
        public int UserId { get; set; }

        [Required]
        public int MedicalServiceId { get; set; }

        // Navigation properties - ОДИН объект, не коллекция!
        public UserDto? User { get; set; }

        public MedicalServiceDto? MedicalService { get; set; }
    }
}
