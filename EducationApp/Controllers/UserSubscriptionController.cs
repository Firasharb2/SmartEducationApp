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
    public class UserSubscriptionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserSubscriptionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserSubscriptions()
        {
            var userSubscriptions = await _context.UserSubscriptions.ToListAsync();
            return Ok(userSubscriptions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserSubscription(int id)
        {
            var userSubscription = await _context.UserSubscriptions.FindAsync(id);
            if (userSubscription == null)
            {
                return NotFound();
            }
            return Ok(userSubscription);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserSubscription([FromForm] UserSubscription userSubscription)
        {
            _context.UserSubscriptions.Add(userSubscription);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserSubscription), new { id = userSubscription.UserSubscriptionId }, userSubscription);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserSubscription(int id, [FromForm] UserSubscription userSubscription)
        {
            if (id != userSubscription.UserSubscriptionId)
            {
                return BadRequest();
            }

            _context.Entry(userSubscription).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserSubscription(int id)
        {
            var userSubscription = await _context.UserSubscriptions.FindAsync(id);
            if (userSubscription == null)
            {
                return NotFound();
            }

            _context.UserSubscriptions.Remove(userSubscription);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}