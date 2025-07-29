using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Application.Services;
using StudentsManagement.Entities;

namespace StudentsManagement.StudentsManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectService _subjectService;
        public SubjectController(SubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public ActionResult<Subject[]> getAllSubject()
        {
            return _subjectService.getAllSubjects();
        }
    }
}
