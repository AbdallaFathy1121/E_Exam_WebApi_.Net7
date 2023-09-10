using Application.DTOs.Exam;
using Application.DTOs.Question;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_Exam_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly IQuestionService _questionService;
        public ExamsController(IExamService examService, IQuestionService questionService)
        {
            _examService = examService;
            _questionService = questionService;
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

        // POST api/Exams/Add
        [HttpPost("Add")]
        public async Task<IActionResult> AddNewExamAsync([FromBody] AddExamDTO dto)
        {
            var result = await _examService.AddNewExamAsync(dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Exams/5/Update
        [HttpPost("{id}/Update")]
        public async Task<IActionResult> UpdateExamAsync(int id, [FromBody] UpdateExamDTO dto)
        {
            var result = await _examService.UpdateExamByIdAsync(id, dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Exams/Delete
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteExamAsync([FromBody] int id)
        {
            var result = await _examService.RemoveExamByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        ///////////////////////////////////////////////////////////
        ////* Questions *////

        // GET: api/Exams/5/Questions
        [HttpGet("{examId}/Questions")]
        public async Task<IActionResult> GetAllQuestionsAsync(int examId)
        {
            var result = await _questionService.GetAllQuestionsByExamIdAsync(examId);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // GET: api/Exams/5/Questions/5
        [HttpGet("{examId}/Questions/{id}")]
        public async Task<IActionResult> GetQuestionByIdAsync(int examId, int id)
        {
            var result = await _questionService.GetQuestionByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Exams/5/Questions/Add
        [HttpPost("{examId}/Questions/Add")]
        public async Task<IActionResult> AddNewQuestionAsync(int examId, [FromBody] AddQuestionDTO dto)
        {
            var result = await _questionService.AddNewQuestionAsync(dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Exams/5/Questions/5/Update
        [HttpPost("{examId}/Questions/{id}/Update")]
        public async Task<IActionResult> UpdateQuestionByIdAsync(int examId, int id,  [FromBody] UpdateQuestionDTO dto)
        {
            var result = await _questionService.UpdateQuestionByIdAsync(id, dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Exams/5/Questions/Delete
        [HttpPost("{examId}/Questions/Delete")]
        public async Task<IActionResult> RemoveQuestionByIdAsync(int examId, [FromBody] int id)
        {
            var result = await _questionService.RemoveQuestionByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }



    }
}
