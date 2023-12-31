﻿using Application.DTOs.Subject;
using Application.Interfaces.Services;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Exam_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        // POST api/Subjects/Add
        [Authorize(Roles = Roles.Teacher)]
        [HttpPost("Add")]
        public async Task<IActionResult> AddNewSubjectAsync([FromBody] AddSubjectDTO dto)
        {
            var result = await _subjectService.AddNewSubjectAsync(dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Subjects/5/Update
        [Authorize(Roles = Roles.Teacher)]
        [HttpPost("{id}/Update")]
        public async Task<IActionResult> UpdateSubjectAsync(int id, [FromBody] UpdateSubjectDTO dto)
        {
            var result = await _subjectService.UpdateSubjectByIdAsync(id, dto);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/Subjects/Delete
        [Authorize(Roles = Roles.Teacher)]
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
