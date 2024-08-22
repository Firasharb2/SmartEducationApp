using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.Controllers
{
    using EducationApp.Domain.Models;
    using EducationApp.Domain;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class UserRatingReviewController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserRatingReviewController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserRatingReviews()
        {
            var userRatingReviews = await _context.UserRatingReviews.ToListAsync();
            return Ok(userRatingReviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserRatingReview(int id)
        {
            var userRatingReview = await _context.UserRatingReviews.FindAsync(id);
            if (userRatingReview == null)
            {
                return NotFound();
            }
            return Ok(userRatingReview);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserRatingReview([FromForm] UserRatingReview userRatingReview)
        {
            _context.UserRatingReviews.Add(userRatingReview);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserRatingReview), new { id = userRatingReview.UserRatingReviewId }, userRatingReview);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserRatingReview(int id, [FromForm] UserRatingReview userRatingReview)
        {
            if (id != userRatingReview.UserRatingReviewId)
            {
                return BadRequest();
            }

            _context.Entry(userRatingReview).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRatingReview(int id)
        {
            var userRatingReview = await _context.UserRatingReviews.FindAsync(id);
            if (userRatingReview == null)
            {
                return NotFound();
            }

            _context.UserRatingReviews.Remove(userRatingReview);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}