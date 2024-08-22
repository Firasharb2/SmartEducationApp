namespace EducationApp.Interfaces
{
    using EducationApp.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICourseEnrollmentService
    {
        Task<IEnumerable<CourseEnrollment>> GetCourseEnrollmentsAsync();
        Task<CourseEnrollment> GetCourseEnrollmentByIdAsync(int id);
        Task<CourseEnrollment> CreateCourseEnrollmentAsync(CourseEnrollment courseEnrollment);
        Task<bool> UpdateCourseEnrollmentAsync(int id, CourseEnrollment courseEnrollment);
        Task<bool> DeleteCourseEnrollmentAsync(int id);
    }

}
