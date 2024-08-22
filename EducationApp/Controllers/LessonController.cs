using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EducationApp.Domain.Models;
using EducationApp.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EducationApp.Interfaces;

namespace EducationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLessons()
        {
            var lessons = await _lessonService.GetLessonsAsync();
            return Ok(lessons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLesson(int id)
        {
            var lesson = await _lessonService.GetLessonByIdAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            return Ok(lesson);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLesson([FromForm] Lesson lesson)
        {
            var createdLesson = await _lessonService.CreateLessonAsync(lesson);
            return CreatedAtAction(nameof(GetLesson), new { id = createdLesson.LessonId }, createdLesson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(int id, [FromForm] Lesson lesson)
        {
            if (!await _lessonService.UpdateLessonAsync(id, lesson))
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            if (!await _lessonService.DeleteLessonAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
