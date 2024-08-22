namespace EducationApp.Interfaces
{
    using EducationApp.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IQuizQuestionService
    {
        Task<IEnumerable<QuizQuestion>> GetQuizQuestionsAsync();
        Task<QuizQuestion> GetQuizQuestionByIdAsync(int id);
        Task<QuizQuestion> CreateQuizQuestionAsync(QuizQuestion quizQuestion);
        Task<bool> UpdateQuizQuestionAsync(int id, QuizQuestion quizQuestion);
        Task<bool> DeleteQuizQuestionAsync(int id);
    }

}
