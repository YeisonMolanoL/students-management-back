using StudentsManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Application.Responses
{
    public class StudentDetailResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public List<StudentSubject> Subjects { get; set; }
    }
}
