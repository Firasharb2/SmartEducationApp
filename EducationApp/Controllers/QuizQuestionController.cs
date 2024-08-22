using EducationApp.Domain.Models;
using EducationApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizQuestionController : ControllerBase
    {
        private readonly IQuizQuestionService _quizQuestionService;

        public QuizQuestionController(IQuizQuestionService quizQuestionService)
        {
            _quizQuestionService = quizQuestionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuizQuestions()
        {
            var quizQuestions = await _quizQuestionService.GetQuizQuestionsAsync();
            return Ok(quizQuestions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizQuestion(int id)
        {
            var quizQuestion = await _quizQuestionService.GetQuizQuestionByIdAsync(id);
            if (quizQuestion == null)
            {
                return NotFound();
            }
            return Ok(quizQuestion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuizQuestion([FromForm] QuizQuestion quizQuestion)
        {
            var createdQuizQuestion = await _quizQuestionService.CreateQuizQuestionAsync(quizQuestion);
            return CreatedAtAction(nameof(GetQuizQuestion), new { id = createdQuizQuestion.QuizQuestionId }, createdQuizQuestion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuizQuestion(int id, [FromForm] QuizQuestion quizQuestion)
        {
            if (!await _quizQuestionService.UpdateQuizQuestionAsync(id, quizQuestion))
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizQuestion(int id)
        {
            if (!await _quizQuestionService.DeleteQuizQuestionAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
