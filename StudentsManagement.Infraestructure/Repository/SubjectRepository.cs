using Microsoft.EntityFrameworkCore;
using StudentsManagement.Entities;
using StudentsManagement.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Infraestructure.Repository
{
    public class SubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Subject[] getAllSubjects()
        {
            return _context.Subjects.Include(o => o.Teacher).ToArray();
        }
    }
}
