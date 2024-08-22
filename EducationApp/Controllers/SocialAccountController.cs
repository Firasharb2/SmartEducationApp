using EducationApp.Domain.Models;
using EducationApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialAccountController : ControllerBase
    {
        private readonly ISocialAccountService _socialAccountService;

        public SocialAccountController(ISocialAccountService socialAccountService)
        {
            _socialAccountService = socialAccountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSocialAccounts()
        {
            var socialAccounts = await _socialAccountService.GetSocialAccountsAsync();
            return Ok(socialAccounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialAccount(int id)
        {
            var socialAccount = await _socialAccountService.GetSocialAccountByIdAsync(id);
            if (socialAccount == null)
            {
                return NotFound();
            }
            return Ok(socialAccount);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialAccount([FromForm] SocialAccount socialAccount)
        {
            var createdSocialAccount = await _socialAccountService.CreateSocialAccountAsync(socialAccount);
            return CreatedAtAction(nameof(GetSocialAccount), new { id = createdSocialAccount.SocialAccountId }, createdSocialAccount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSocialAccount(int id, [FromForm] SocialAccount socialAccount)
        {
            if (!await _socialAccountService.UpdateSocialAccountAsync(id, socialAccount))
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialAccount(int id)
        {
            if (!await _socialAccountService.DeleteSocialAccountAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
