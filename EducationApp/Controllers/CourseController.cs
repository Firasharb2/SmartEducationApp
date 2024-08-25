using Microsoft.AspNetCore.Http;

namespace EducationApp.Controllers
{
    using EducationApp.Domain.Models;
    using EducationApp.Domain;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
   
    [ApiController]
    [Route("course")]
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext _context;
        private string _userId;
        public CourseController(AppDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userId = httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

        }

        [HttpGet("get-courses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = new List<Course>();
                
            var enrolledCources = await _context.CourseEnrollments.Where(c=>c.UserId == _userId).Select(c=>c.CourseId).ToListAsync();

            if (enrolledCources.Count > 0)
            {
                courses = await _context.Courses.Where(c=>!enrolledCources.Contains(c.CourseId))// Include related entities if needed
                .ToListAsync();
            }
            else
            {
                courses =  await _context.Courses// Include related entities if needed
               .ToListAsync();
            }

            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await _context.Courses
                .FirstOrDefaultAsync(c => c.CourseId == id);

            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost("create-course")]
        public async Task<IActionResult> CreateCourse([FromBody] Course course)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCourse), new { id = course.CourseId }, course);

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromForm] Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(course).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}