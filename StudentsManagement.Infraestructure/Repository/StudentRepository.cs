using Microsoft.EntityFrameworkCore;
using StudentsManagement.Entities;
using StudentsManagement.Infraestructure.Data;
using StudentsManagement.StudentsManagement.Shared.Exceptions;
using System.Diagnostics;

namespace StudentsManagement.StudentsManagement.Infraestructure.Repository
{
    public class StudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext contextDbContex)
        {
            _context = contextDbContex;
        }

        public async Task<List<Student>> getAllStudents()
        {
            return this._context.Students.ToList();
        }

        public async Task<Student> getStudentByIdAsync(int Id)
        {
            return await _context.Students
        .       Include(s => s.Subjects)
                .ThenInclude(ss => ss.Subject)
                .ThenInclude(sub => sub.Teacher)
                .FirstOrDefaultAsync(s => s.Id == Id);
        }

        public async Task<Student> GetUniqueStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public Student SaveStudent(Student student)
        {
            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return student;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("🔥 Error TRACE: " + ex.Message);
                throw new StudentsManagementException(ex.InnerException.Message);
            }
        }

        public Student UpdateStudent(Student student)
        {
            try
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return student;
            }
            catch (Exception ex)
            {
                throw new StudentsManagementException(ex.InnerException.Message);
            }
        }
    }
}
