using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Application.Dto
{
    public class StudentSubjectDto
    {
        public int StudentId { get; set; }
        public List<int> SubjectIds { get; set; }
    }
}
