using System.ComponentModel.DataAnnotations;

namespace MIS.Core.InputModels
{
    public class UserInputModel

    {
        [Required(ErrorMessage = "Имя обязательно!!!!")]
        [MaxLength(150, ErrorMessage = "Имя не должно превышать 100 символов")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Фамилия обязательна")]
        [MaxLength(150, ErrorMessage = "Фамилия не должна превышать 100 символов")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный формат email")]
        [MaxLength(100, ErrorMessage = "Email не должен превышать 100 символов")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Пароль обязателен")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Пароль должен быть от 1 до 100 символов")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = string.Empty;      
        

        [Phone(ErrorMessage = "Некорректный формат телефона")]
        [MaxLength(100, ErrorMessage = "Телефон не должен превышать 100 символов")]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Дата рождения обязательна")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Укажите пол")]
        [Display(Name = "Пол")]

        public UserRole Role { get; set; } = UserRole.Client;

        public Gender Gender { get; set; } = Gender.Unknown;

        public bool IsRemoved { get; set; } = false;  //флаг удаления пользователя
    }
}
