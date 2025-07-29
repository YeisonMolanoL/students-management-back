using StudentsManagement.Application.Dto;
using StudentsManagement.Entities;
using StudentsManagement.Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Application.Services
{
    public class StudentSubjectService
    {
        private readonly StudentSubjectReporistory _studentSubjectReporistory;
        public StudentSubjectService(StudentSubjectReporistory studentSubjectReporistory)
        {
            _studentSubjectReporistory = studentSubjectReporistory;
        }

        public async Task insertStudentSubject(StudentSubjectDto studentSubjectDto)
        {
            var studentSubjects = studentSubjectDto.SubjectIds.Select(subjectId => new StudentSubject
            {
                StudentId = studentSubjectDto.StudentId,
                SubjectId = subjectId
            }).ToList();
            await _studentSubjectReporistory.AddRangeAsync(studentSubjects);
        }

        public async Task<List<string>> getStudentsBySubjectId(int id)
        {
            return await _studentSubjectReporistory.GetAllBySubjectIdAsync(id);
        }

        public async Task DeleteStudentSubjectByStudentId(int id)
        {
            await _studentSubjectReporistory.DeleteByStudentIdAsync(id);
        }
    }
}
