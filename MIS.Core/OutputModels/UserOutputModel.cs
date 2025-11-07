using MIS.Core.Dtos;
using System.ComponentModel.DataAnnotations;

namespace MIS.Core.OutputModels
{
    public class UserOutputModel
    {
        public int Id { get; set; }

        public UserRole Role { get; set; }

        public Gender Gender { get; set; }
       
        public string FullName { get; set; }
        
        //public string FirstName { get; set; } 

        //public string LastName { get; set; }
      
        public string Email { get; set; }
        
        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsRemoved { get; set; }  //флаг удаления пользователя

        // Navigation property - коллекция заказов
        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
    }
}
