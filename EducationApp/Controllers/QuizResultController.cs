using EducationApp.Domain.Models;
using EducationApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizResultController : ControllerBase
    {
        private readonly IQuizResultService _quizResultService;

        public QuizResultController(IQuizResultService quizResultService)
        {
            _quizResultService = quizResultService;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuizResults()
        {
            var quizResults = await _quizResultService.GetQuizResultsAsync();
            return Ok(quizResults);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizResult(int id)
        {
            var quizResult = await _quizResultService.GetQuizResultByIdAsync(id);
            if (quizResult == null)
            {
                return NotFound();
            }
            return Ok(quizResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuizResult([FromForm] QuizResult quizResult)
        {
            var createdQuizResult = await _quizResultService.CreateQuizResultAsync(quizResult);
            return CreatedAtAction(nameof(GetQuizResult), new { id = createdQuizResult.QuizResultId }, createdQuizResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuizResult(int id, [FromForm] QuizResult quizResult)
        {
            if (!await _quizResultService.UpdateQuizResultAsync(id, quizResult))
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizResult(int id)
        {
            if (!await _quizResultService.DeleteQuizResultAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
