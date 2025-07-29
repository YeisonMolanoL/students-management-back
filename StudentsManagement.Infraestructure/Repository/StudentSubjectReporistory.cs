using Microsoft.EntityFrameworkCore;
using StudentsManagement.Entities;
using StudentsManagement.Infraestructure.Data;

namespace StudentsManagement.Infraestructure.Repository
{
    public class StudentSubjectReporistory
    {
        private readonly ApplicationDbContext _context;

        public StudentSubjectReporistory(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<StudentSubject> studentSubjects)
        {
            await _context.StudentSubjects.AddRangeAsync(studentSubjects);
            await _context.SaveChangesAsync();
        }

        public Task<List<string>> GetAllBySubjectIdAsync(int id)
        {
            return _context.StudentSubjects
                .Where(ss => ss.SubjectId == id)
                .Select(ss => ss.Student.Name + " " + ss.Student.Surname)
                .Distinct()
                .ToListAsync();
        }

        public async Task DeleteByStudentIdAsync(int id)
        {
            try
            {
                var studentSubjects = await _context.StudentSubjects
                .Where(ss => ss.StudentId == id)
                .ToListAsync();

            if (studentSubjects.Any())
            {
                _context.StudentSubjects.RemoveRange(studentSubjects);
                await _context.SaveChangesAsync();
            }
            }
            catch (Exception ex)
            {
                // Loguea el error para depuración
                Console.WriteLine($"Error al eliminar: {ex.Message}");
                throw new Exception();
            }
        }
    }
}
