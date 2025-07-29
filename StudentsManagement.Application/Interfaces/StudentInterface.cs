using StudentsManagement.Entities;
using StudentsManagement.StudentsManagement.Application.Dto;

namespace StudentsManagement.StudentsManagement.Application.Interfaces
{
    public interface StudentInterface
    {
        Task<Student> RegisterAsync(CreateStudentDto dto);
    }
}
