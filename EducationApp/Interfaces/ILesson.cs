namespace EducationApp.Interfaces
{
    using EducationApp.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILessonService
    {
        Task<IEnumerable<Lesson>> GetLessonsAsync();
        Task<Lesson> GetLessonByIdAsync(int id);
        Task<Lesson> CreateLessonAsync(Lesson lesson);
        Task<bool> UpdateLessonAsync(int id, Lesson lesson);
        Task<bool> DeleteLessonAsync(int id);
    }

}
