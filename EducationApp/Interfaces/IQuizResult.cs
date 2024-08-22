namespace EducationApp.Interfaces
{
    using EducationApp.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IQuizResultService
    {
        Task<IEnumerable<QuizResult>> GetQuizResultsAsync();
        Task<QuizResult> GetQuizResultByIdAsync(int id);
        Task<QuizResult> CreateQuizResultAsync(QuizResult quizResult);
        Task<bool> UpdateQuizResultAsync(int id, QuizResult quizResult);
        Task<bool> DeleteQuizResultAsync(int id);
    }

}
