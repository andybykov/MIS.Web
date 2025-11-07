using System.ComponentModel.DataAnnotations;

namespace MIS.Core.InputModels
{
    public class MedicalServiceInputModel
    {
        [Required(ErrorMessage = "Имя услугли обязательно")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Цена услугли обязательна")]
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public bool IsRemoved { get; set; } = false;

    }
}
