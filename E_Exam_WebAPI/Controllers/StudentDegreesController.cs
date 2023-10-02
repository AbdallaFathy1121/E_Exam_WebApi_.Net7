using Application.DTOs.StudentDegree;
using Application.Interfaces.Services;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Exam_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentDegreesController : ControllerBase
    {
        private readonly IStudentDegreeService _studentDegreeService;
        public StudentDegreesController(IStudentDegreeService studentDegreeService)
        {
            _studentDegreeService = studentDegreeService;
        }


        // POST: api/StudentDegrees/Add
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] AddStudentDegreeDTO dto)
        {
            var result = await _studentDegreeService.AddStudentDegreeAsync(dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // GET api/StudentDegrees
        [HttpGet]
        [Authorize(Roles =Roles.Admin)]
        public async Task<IActionResult> GetAllAsync() 
        {
            var result = await _studentDegreeService.GetAllStudentDegreesAsync();
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // GET api/StudentDegrees/SubjectId/5
        [HttpGet("SubjectId/{id}")]
        [Authorize(Roles = Roles.Teacher)]
        public async Task<IActionResult> GetDegreesBySubjectIdAsync(int id)
        {
            var result = await _studentDegreeService.GetStudentDegreesBySubjectIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // GET api/StudentDegrees/UserId/5
        [HttpGet("UserId/{id}")]
        public async Task<IActionResult> GetDegreesByUserIdAsync(string id)
        {
            var result = await _studentDegreeService.GetStudentDegreesByUserIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // GET api/StudentDegrees/UserId/{userId}/SubjectId/{subjectId}
        [HttpGet("UserId/{userId}/SubjectId/{subjectId}")]
        public async Task<IActionResult> GetDegreesBySubjectIdAndUserIdAsync(string userId, int subjectId)
        {
            var result = await _studentDegreeService.GetStudentDegreeByUserIdAndSubjectIDAsync(userId, subjectId);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
