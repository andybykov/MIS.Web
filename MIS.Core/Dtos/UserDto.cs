using System.ComponentModel.DataAnnotations;

namespace MIS.Core.Dtos
{
    
    public class UserDto
    {
        public int Id { get; set; }

        public UserRole Role { get; set; } = UserRole.Client;

        public Gender? Gender { get; set; }

        [MaxLength(150)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(150)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Email { get; set; } = string.Empty; //email

        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;

        [MaxLength(100)]
        public string PhoneNumber { get; set; } =  string.Empty;

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow; // UTC

        public DateTime? DateOfBirth { get; set; }

        public bool IsRemoved { get; set; }

        // Navigation property - коллекция заказов
        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
    }
}
