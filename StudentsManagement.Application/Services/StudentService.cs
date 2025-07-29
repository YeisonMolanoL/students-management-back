
using StudentsManagement.Application.Dto;
using StudentsManagement.Application.Responses;
using StudentsManagement.Application.Services;
using StudentsManagement.Entities;
using StudentsManagement.StudentsManagement.Application.Dto;
using StudentsManagement.StudentsManagement.Infraestructure.Repository;
using StudentsManagement.StudentsManagement.Shared.Exceptions;
using System.Diagnostics;

namespace StudentsManagement.StudentsManagement.Application.Services
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;
        private readonly StudentSubjectService _studentSubjectService;

        public StudentService(StudentRepository studentRepository, StudentSubjectService studentSubjectService) {
            _studentRepository = studentRepository;
            _studentSubjectService = studentSubjectService;
        }

        public async Task<int> CreateStudent(CreateStudentDto createStudentDto) {
            Student newStudent = new Student();
            newStudent.Name = createStudentDto.Name;
            newStudent.Surname = createStudentDto.Surname;
            newStudent.Email = createStudentDto.Email;
            newStudent.Phone = createStudentDto.Phone;
            _studentRepository.SaveStudent(newStudent);
            if(createStudentDto.subjects.Count() > 0)
            {
                StudentSubjectDto studentSubject = new StudentSubjectDto();
                studentSubject.SubjectIds = createStudentDto.subjects;
                studentSubject.StudentId = newStudent.Id;
                await _studentSubjectService.insertStudentSubject(studentSubject);
            }
            return newStudent.Id;
        }

        public async Task<Student> getStudentById(int Id)
        {
            return await _studentRepository.getStudentByIdAsync(Id);
        }

        public async Task<Student> UpdateStudentById(UpdateStudentDto updateStudentDto)
        {
            var studentFound = await _studentRepository.GetUniqueStudentByIdAsync(updateStudentDto.StudentId);
            if (studentFound == null) throw new StudentsManagementException("user.not.found");

            studentFound.Name = updateStudentDto.Name;
            studentFound.Surname = updateStudentDto.Surname;
            studentFound.Phone = updateStudentDto.Phone;

            if (updateStudentDto.subjects.Count() > 0)
            {
                await _studentSubjectService.DeleteStudentSubjectByStudentId(updateStudentDto.StudentId);
                StudentSubjectDto studentSubject = new StudentSubjectDto();
                studentSubject.SubjectIds = updateStudentDto.subjects;
                studentSubject.StudentId = updateStudentDto.StudentId;
                await _studentSubjectService.insertStudentSubject(studentSubject);
            }
            return _studentRepository.UpdateStudent(studentFound);
        }

        public Task<List<Student>> GetAllStudents()
        {
            return _studentRepository.getAllStudents();
        }
    }
}
