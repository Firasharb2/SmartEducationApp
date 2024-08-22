namespace EducationApp.Services
{
    using EducationApp.Domain;
    using EducationApp.Domain.Models;
    using EducationApp.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class QuizResultService : IQuizResultService
    {
        private readonly AppDbContext _context;

        public QuizResultService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuizResult>> GetQuizResultsAsync()
        {
            return await _context.QuizResults.ToListAsync();
        }

        public async Task<QuizResult> GetQuizResultByIdAsync(int id)
        {
            return await _context.QuizResults.FindAsync(id);
        }

        public async Task<QuizResult> CreateQuizResultAsync(QuizResult quizResult)
        {
            _context.QuizResults.Add(quizResult);
            await _context.SaveChangesAsync();
            return quizResult;
        }

        public async Task<bool> UpdateQuizResultAsync(int id, QuizResult quizResult)
        {
            if (id != quizResult.QuizResultId)
            {
                return false;
            }

            _context.Entry(quizResult).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteQuizResultAsync(int id)
        {
            var quizResult = await _context.QuizResults.FindAsync(id);
            if (quizResult == null)
            {
                return false;
            }

            _context.QuizResults.Remove(quizResult);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
