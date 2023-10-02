using Application.DTOs.Question;
using Application.DTOs.Subject;
using Application.Interfaces.Services;
using Domain.Constants;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Exam_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }


        // GET: api/Questions/{SubjectId}
        [HttpGet("{subjectId}")]
        public async Task<IActionResult> GetQuestionsBySubjectIdAsync(int subjectId)
        {
            var result = await _questionService.GetAllQuestionsBySubjectIdAsync(subjectId);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Questions/Add
        [HttpPost("Add")]
        [Authorize(Roles = Roles.Teacher)]
        public async Task<IActionResult> AddNewQuestionAsync([FromBody] AddQuestionDTO dto)
        {
            var result = await _questionService.AddNewQuestionAsync(dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Questions/{id}/Update
        [HttpPost("{id}/Update")]
        [Authorize(Roles = Roles.Teacher)]
        public async Task<IActionResult> UpdateQuestionAsync(int id, [FromBody] UpdateQuestionDTO dto)
        {
            var result = await _questionService.UpdateQuestionByIdAsync(id, dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Question/Delete
        [HttpPost("Delete")]
        [Authorize(Roles = Roles.Teacher)]
        public async Task<IActionResult> DeleteQuestionAsync([FromBody] DeleteQuestionDTO dto)
        {
            var result = await _questionService.RemoveQuestionByIdAsync(dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
