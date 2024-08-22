namespace EducationApp.Services
{
    using EducationApp.Domain;
    using EducationApp.Domain.Models;
    using EducationApp.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class QuizQuestionService : IQuizQuestionService
    {
        private readonly AppDbContext _context;

        public QuizQuestionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuizQuestion>> GetQuizQuestionsAsync()
        {
            return await _context.QuizQuestions.ToListAsync();
        }

        public async Task<QuizQuestion> GetQuizQuestionByIdAsync(int id)
        {
            return await _context.QuizQuestions.FindAsync(id);
        }

        public async Task<QuizQuestion> CreateQuizQuestionAsync(QuizQuestion quizQuestion)
        {
            _context.QuizQuestions.Add(quizQuestion);
            await _context.SaveChangesAsync();
            return quizQuestion;
        }

        public async Task<bool> UpdateQuizQuestionAsync(int id, QuizQuestion quizQuestion)
        {
            if (id != quizQuestion.QuizQuestionId)
            {
                return false;
            }

            _context.Entry(quizQuestion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteQuizQuestionAsync(int id)
        {
            var quizQuestion = await _context.QuizQuestions.FindAsync(id);
            if (quizQuestion == null)
            {
                return false;
            }

            _context.QuizQuestions.Remove(quizQuestion);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
