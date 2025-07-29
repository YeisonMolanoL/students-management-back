using StudentsManagement.Entities;
using StudentsManagement.Infraestructure.Repository;

namespace StudentsManagement.Application.Services
{
    public class TeachersService
    {
        private readonly TeacherRepository _teacherRepository;

        public TeachersService(TeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public List<Teacher> getAllTeachers()
        {
            return _teacherRepository.getAllTeachers();
        }
    }
}
