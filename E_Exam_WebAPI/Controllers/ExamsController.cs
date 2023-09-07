using Application.DTOs.Exam;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_Exam_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;
        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }


        // GET: api/Exams
        [HttpGet]
        public async Task<IActionResult> GetAllExamsAsync()
        {
            var result = await _examService.GetAllExamsAsync();
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // GET: api/Exams/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamByIdAsync(int id)
        {
            var result = await _examService.GetExamByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Exams/AddNewExam
        [HttpPost("AddNewExam")]
        public async Task<IActionResult> AddNewExamAsync([FromBody] AddExamDTO dto)
        {
            var result = await _examService.AddNewExamAsync(dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Exams/Update/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateExamAsync(int id, [FromBody] UpdateExamDTO dto)
        {
            var result = await _examService.UpdateExamByIdAsync(id, dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Exams/Delete/5
        [HttpPut("Delete/{id}")]
        public async Task<IActionResult> DeleteExamAsync(int id)
        {
            var result = await _examService.RemoveExamByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
