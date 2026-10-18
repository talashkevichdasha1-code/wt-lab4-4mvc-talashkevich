
using System.ComponentModel.DataAnnotations;

namespace wt_lab4_4mvc_talashkevich.Models
{
    public class MemberCreateViewModel
    {
        [Required(ErrorMessage = "Введите имя участника")]
        [StringLength(100, ErrorMessage = "Имя не должно превышать 100 символов")]
        public string Name { get; set; } = string.Empty;

        [Range(14, 100, ErrorMessage = "Возраст должен быть от 14 до 100 лет")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Выберите тип абонемента")]
        public string MembershipType { get; set; } = string.Empty;
    }
}
