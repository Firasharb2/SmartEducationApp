using EducationApp.Domain.Models;
using EducationApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionPlanController : ControllerBase
    {
        private readonly ISubscriptionPlanService _subscriptionPlanService;

        public SubscriptionPlanController(ISubscriptionPlanService subscriptionPlanService)
        {
            _subscriptionPlanService = subscriptionPlanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubscriptionPlans()
        {
            var subscriptionPlans = await _subscriptionPlanService.GetSubscriptionPlansAsync();
            return Ok(subscriptionPlans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriptionPlan(int id)
        {
            var subscriptionPlan = await _subscriptionPlanService.GetSubscriptionPlanByIdAsync(id);
            if (subscriptionPlan == null)
            {
                return NotFound();
            }
            return Ok(subscriptionPlan);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscriptionPlan([FromForm] SubscriptionPlan subscriptionPlan)
        {
            var createdSubscriptionPlan = await _subscriptionPlanService.CreateSubscriptionPlanAsync(subscriptionPlan);
            return CreatedAtAction(nameof(GetSubscriptionPlan), new { id = createdSubscriptionPlan.SubscriptionPlanId }, createdSubscriptionPlan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubscriptionPlan(int id, [FromForm] SubscriptionPlan subscriptionPlan)
        {
            if (!await _subscriptionPlanService.UpdateSubscriptionPlanAsync(id, subscriptionPlan))
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionPlan(int id)
        {
            if (!await _subscriptionPlanService.DeleteSubscriptionPlanAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
