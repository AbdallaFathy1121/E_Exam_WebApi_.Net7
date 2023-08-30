using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Exam_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public LevelsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/<LevelsController>
        [HttpGet]
        public async Task<IActionResult> Levels()
        {
            var result = await _unitOfWork.LevelRepository.GetAllAsync();
            return Ok(result);
        }

        // GET api/<LevelsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Levels(int id)
        {
            var result = await _unitOfWork.LevelRepository.GetFirstAsync(a => a.Id == id);
            return Ok(result);
        }

        // POST api/<LevelsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string name)
        {
            var model = new Level { LevelName =  name };
            var result = await _unitOfWork.LevelRepository.AddAsync(model);
            await _unitOfWork.Complete();
            return Ok(result);
        }

        // PUT api/<LevelsController>/5
        [HttpPost("Update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string name)
        {
            var exists = await _unitOfWork.LevelRepository.GetFirstAsync(a => a.Id == id);
            if (exists is not null)
            {
                exists.LevelName = name;
                await _unitOfWork.LevelRepository.Update(exists);
                await _unitOfWork.Complete();

                return Ok(exists);
            }
            else
            {
                return NotFound("Not found Level with ID: " + id);
            }
        }

        // DELETE api/<LevelsController>/5
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _unitOfWork.LevelRepository.GetFirstAsync(a => a.Id == id);
            if (exists is not null)
            {
                await _unitOfWork.LevelRepository.DeleteAsync(exists);
                await _unitOfWork.Complete();

                return Ok(exists);
            }
            else
            {
                return NotFound("Not found Level with ID: " + id);
            }
        }
    }
}
