using EducationApp.Domain.Models;
using EducationApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace EducationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseEnrollmentController : ControllerBase
    {
        private readonly ICourseEnrollmentService _courseEnrollmentService;

        public CourseEnrollmentController(ICourseEnrollmentService courseEnrollmentService)
        {
            _courseEnrollmentService = courseEnrollmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseEnrollments()
        {
            var courseEnrollments = await _courseEnrollmentService.GetCourseEnrollmentsAsync();
            return Ok(courseEnrollments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseEnrollment(int id)
        {
            var courseEnrollment = await _courseEnrollmentService.GetCourseEnrollmentByIdAsync(id);
            if (courseEnrollment == null)
            {
                return NotFound();
            }
            return Ok(courseEnrollment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseEnrollment([FromForm] CourseEnrollment courseEnrollment)
        {
            var createdEnrollment = await _courseEnrollmentService.CreateCourseEnrollmentAsync(courseEnrollment);
            return CreatedAtAction(nameof(GetCourseEnrollment), new { id = createdEnrollment.CourseEnrollmentId }, createdEnrollment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourseEnrollment(int id, [FromForm] CourseEnrollment courseEnrollment)
        {
            if (!await _courseEnrollmentService.UpdateCourseEnrollmentAsync(id, courseEnrollment))
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseEnrollment(int id)
        {
            if (!await _courseEnrollmentService.DeleteCourseEnrollmentAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

