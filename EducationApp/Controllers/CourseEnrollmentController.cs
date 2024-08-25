using EducationApp.Domain.Models;
using EducationApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace EducationApp.Controllers
{
    [Route("enrolled-course")]
    [ApiController]
    public class CourseEnrollmentController : ControllerBase
    {
        private readonly ICourseEnrollmentService _courseEnrollmentService;
        private string _userId ;
        public CourseEnrollmentController(ICourseEnrollmentService courseEnrollmentService, IHttpContextAccessor httpContextAccessor)
        {
            _courseEnrollmentService = courseEnrollmentService;
            _userId = httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

        }

        [HttpGet("add-course/{id}")]
        public async Task<IActionResult> AddCourse(int id)
        {
            try
            {
                CourseEnrollment courseEnrollment = new()
                {
                     CourseId = id, EnrolledAt = DateTime.UtcNow, UserId = _userId,Grade = "0"
                };
                await _courseEnrollmentService.CreateCourseEnrollmentAsync(courseEnrollment);
                //return CreatedAtAction(nameof(GetCourse), new { id = id }, course);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }

        }



        [HttpGet("drop-course/{id}")]
        public async Task<IActionResult> DropCourse(int id)
        {
            try
            {
                await _courseEnrollmentService.DeleteCourseEnrollmentAsync(id);
                //return CreatedAtAction(nameof(GetCourse), new { id = id }, course);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        [HttpGet("get-courses")]
        public async Task<IActionResult> GetCourses()
        {

            var enrolledCources = (await  _courseEnrollmentService.GetCourseEnrollmentsAsync(_userId)).ToList();

            var enrolledCoursesDetails = enrolledCources.Select(course => new EnrolledCourcesDetails
            {
                id = course.CourseEnrollmentId,
               Title = course.Course.Title,
               ImageUrl = course.Course.ImageUrl,
                Price   = course.Course.Price
                // Add other properties as needed
            }).ToList();

            return Ok(enrolledCoursesDetails);
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

    public class EnrolledCourcesDetails
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public decimal? Price { get; set; }

    }   
}

