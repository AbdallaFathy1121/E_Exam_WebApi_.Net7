using Application.DTOs.SubjectLevel;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace E_Exam_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectLevelsController : ControllerBase
    {
        private readonly ISubjectLevelService _subjectLevelService;
        public SubjectLevelsController(ISubjectLevelService subjectLevelService)
        {
            _subjectLevelService = subjectLevelService;
        }


        // GET: api/SubjectLevels
        [HttpGet]
        public async Task<IActionResult> GetAllSubjectLevelsAsync()
        {
            var result = await _subjectLevelService.GetAllSubjectLevelsAsync();
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // GET api/SubjectLevels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectLevelByIdAsync(int id)
        {
            var result = await _subjectLevelService.GetSubjectLevelByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }


        // GET api/SubjectLevels/Level/5
        [HttpGet("Level/{levelId}")]
        public async Task<IActionResult> GetSubjectLevelByLevelId(int levelId)
        {
            var result = await _subjectLevelService.GetSubjectLevelsByLevelIdAsync(levelId);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // GET api/SubjectLevels/Subject/5
        [HttpGet("Subject/{subjectId}")]
        public async Task<IActionResult> GetSubjectLevelBySubjectId(int subjectId)
        {
            var result = await _subjectLevelService.GetSubjectLevelsBySubjectIdAsync(subjectId);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/SubjectLevels
        [HttpPost]
        public async Task<IActionResult> AddNewSubjectLevelAsync([FromBody] AddSubjectLevelDTO dto)
        {
            var result = await _subjectLevelService.AddSubjectLevelAsync(dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }
}
