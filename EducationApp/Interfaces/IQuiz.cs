namespace EducationApp.Interfaces
{
    using EducationApp.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IQuizService
    {
        Task<IEnumerable<Quiz>> GetQuizzesAsync();
        Task<Quiz> GetQuizByIdAsync(int id);
        Task<Quiz> CreateQuizAsync(Quiz quiz);
        Task<bool> UpdateQuizAsync(int id, Quiz quiz);
        Task<bool> DeleteQuizAsync(int id);
    }

}
