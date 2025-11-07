using System.ComponentModel.DataAnnotations;

namespace MIS.Core.InputModels
{
    public class OrderInputModel
    {
        [Required(ErrorMessage = "Дата заказа обязательна")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Статус заказа обязателен")]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.New;

        [Required(ErrorMessage = "Сумма заказа обязательна")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Сумма должна быть больше 0")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "ID пользователя обязателен")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "ID услуги обязательно")]
        public int MedicalServiceId { get; set; }
    }
}