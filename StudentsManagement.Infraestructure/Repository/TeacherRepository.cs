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
    public class TeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Teacher> getAllTeachers()
        {
            return _context.Teachers.Include(o=> o.Subjects).ToList();
        }
    }
}
