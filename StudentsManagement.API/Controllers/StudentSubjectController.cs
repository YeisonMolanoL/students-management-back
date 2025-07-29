using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Application.Dto;
using StudentsManagement.Application.Services;
using StudentsManagement.Entities;

namespace StudentsManagement.StudentsManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectController : ControllerBase
    {
        private readonly StudentSubjectService _studentSubjectService;
        public StudentSubjectController(StudentSubjectService studentSubjectService)
        {
            _studentSubjectService = studentSubjectService;
        }

        [HttpPost]
        public void createStudentSubject(StudentSubjectDto studentSubjectDto) {
            _studentSubjectService.insertStudentSubject(studentSubjectDto);
        }

        [HttpGet]
        public Task<List<string>> getStudentsBySubjectId([FromQuery] int id)
        {
            return _studentSubjectService.getStudentsBySubjectId(id);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudentSubjectsByStudentId([FromQuery] int id)
        {
            await _studentSubjectService.DeleteStudentSubjectByStudentId(id);
            return Ok(new { message = "Eliminados correctamente" });
        }
    }
}
