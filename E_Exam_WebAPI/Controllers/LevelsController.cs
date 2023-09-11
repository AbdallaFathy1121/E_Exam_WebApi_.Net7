using Application.DTOs.Level;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Constants;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Exam_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LevelsController : ControllerBase
    {
        private readonly ILevelService _levelService;
        public LevelsController(ILevelService levelService)
        {
            _levelService = levelService;
        }


        // GET: api/Levels
        [HttpGet]
        public async Task<IActionResult> GetAllLevelsAsync()
        {
            var result = await _levelService.GetAllLevelsAsync();
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // GET api/Levels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLevelByIdAsync(int id)
        {
            var result = await _levelService.GetLevelByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            else
                return NotFound(result);
        }

        // POST api/Levels/Add
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("Add")]
        public async Task<IActionResult> CreateNewLevelAsync([FromBody] AddLevelDTO dto)
        {
            var result = await _levelService.AddNewLevelAsync(dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Levels/5/Update
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("{id}/Update")]
        public async Task<IActionResult> UpdateLevelAsync(int id, [FromBody] UpdateLevelDTO dto)
        {
            var result = await _levelService.UpdateLevelByIdAsync(id, dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Levels/Delete
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteLevelAsync([FromBody] DeleteLevelDTO dto)
        {
            var result = await _levelService.RemoveLevelByIdAsync(dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return NotFound(result);
        }
    }
}
