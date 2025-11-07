using MIS.Core.Dtos;
using System.ComponentModel.DataAnnotations;

namespace MIS.Core.OutputModels
{
    public class OrderOutputModel
    {
        public int Id { get; set; }

        // Дата и время создания заказа
        public DateTime Date { get; set; } = DateTime.Now;

        // Статус заказа       
        [Required]
        public OrderStatus OrderStatus { get; set; } 

        // Общая сумма заказа (рассчитывается автоматически)
        public decimal TotalAmount { get; set; }

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
