using System.ComponentModel.DataAnnotations;

namespace StudentsManagement.StudentsManagement.Application.Dto
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [MaxLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no es válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "El número de teléfono no es válido")]
        [MaxLength(50, ErrorMessage = "El número de teléfono no puede tener más de 10 caracteres")]
        public string Phone { get; set; }

        public List<int> subjects { get; set; }
    }
}
