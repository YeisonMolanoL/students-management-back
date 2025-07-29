using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Application.Dto
{
    public class UpdateStudentDto
    {
        [Required(ErrorMessage = "Elid del estudiante es requerido")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [MaxLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "El número de teléfono no es válido")]
        [MaxLength(50, ErrorMessage = "El número de teléfono no puede tener más de 10 caracteres")]
        public string Phone { get; set; }

        public List<int> subjects { get; set; }
    }
}
