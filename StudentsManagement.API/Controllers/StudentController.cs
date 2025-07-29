using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Application.Dto;
using StudentsManagement.Application.Responses;
using StudentsManagement.Entities;
using StudentsManagement.StudentsManagement.Application.Dto;
using StudentsManagement.StudentsManagement.Application.Services;
using System.Diagnostics;

namespace StudentsManagement.StudentsManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;
        public StudentController(StudentService studentService) {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateStudent([FromBody] CreateStudentDto dto)
        {
            if (dto == null) return BadRequest();
            var newStudentId = await _studentService.CreateStudent(dto);
            Debug.WriteLine("🔥 createStudentDto: " + newStudentId);
            return Ok(newStudentId);
        }

        [HttpGet]
        public async Task<ActionResult<Student>> getStudentById([FromQuery] int id)
        {
            return await _studentService.getStudentById(id);
        }

        [HttpPut]
        public async Task<ActionResult<Student>> updateStudentById([FromBody] UpdateStudentDto updateStudentDto)
        {
            return await _studentService.UpdateStudentById(updateStudentDto);
        }

        [HttpGet("all")]
        public async Task<List<Student>> getAllStudents()
        {
            return await _studentService.GetAllStudents();
        }
    }
}
