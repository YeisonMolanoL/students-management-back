using StudentsManagement.Entities;
using StudentsManagement.Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Application.Services
{
    public class SubjectService
    {
        private readonly SubjectRepository _subjectRepository;

        public SubjectService(SubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public Subject[] getAllSubjects()
        {
            return _subjectRepository.getAllSubjects();
        }
    }
}
