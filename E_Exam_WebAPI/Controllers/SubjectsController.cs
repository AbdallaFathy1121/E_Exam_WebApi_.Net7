using Application.DTOs.Subject;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Exam_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }


        // GET: api/Subjects
        [HttpGet]
        public async Task<IActionResult> GetAllSubjectsAsync()
        {
            var result = await _subjectService.GetAllSubjectsAsync();
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // GET api/Subjects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectByIdAsync(int id)
        {
            var result = await _subjectService.GetSubjectByIdAsync(id);
            if (result.IsSuccess) 
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/AddNewSubject
        [HttpPost("AddNewSubject")]
        public async Task<IActionResult> AddNewSubjectAsync([FromBody] AddSubjectDTO dto)
        {
            var result = await _subjectService.AddNewSubjectAsync(dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Subjects/Update/5
        [HttpPost("Update/{id}")]
        public async Task<IActionResult> UpdateSubjectAsync(int id, [FromBody] UpdateSubjectDTO dto)
        {
            var result = await _subjectService.UpdateSubjectByIdAsync(id, dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Subjects/Delete
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteSubjectAsync(DeleteSubjectDTO dto)
        {
            var result = await _subjectService.RemoveSubjectAsync(dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
