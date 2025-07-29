using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Application.Services;
using StudentsManagement.Entities;

namespace StudentsManagement.StudentsManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly TeachersService _teacherService;

        public TeacherController(TeachersService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public ActionResult<List<Teacher>> getAllTeachers()
        {
            return _teacherService.getAllTeachers();
        }
    }
}
