namespace EducationApp.Services
{
    using EducationApp.Domain;
    using EducationApp.Domain.Models;
    using EducationApp.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CourseEnrollmentService : ICourseEnrollmentService
    {
        private readonly AppDbContext _context;

        public CourseEnrollmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseEnrollment>> GetCourseEnrollmentsAsync()
        {
            return await _context.CourseEnrollments.ToListAsync();
        }

        public async Task<CourseEnrollment> GetCourseEnrollmentByIdAsync(int id)
        {
            return await _context.CourseEnrollments.FindAsync(id);
        }

        public async Task<CourseEnrollment> CreateCourseEnrollmentAsync(CourseEnrollment courseEnrollment)
        {
            _context.CourseEnrollments.Add(courseEnrollment);
            await _context.SaveChangesAsync();
            return courseEnrollment;
        }

        public async Task<bool> UpdateCourseEnrollmentAsync(int id, CourseEnrollment courseEnrollment)
        {
            if (id != courseEnrollment.CourseEnrollmentId)
            {
                return false;
            }

            _context.Entry(courseEnrollment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCourseEnrollmentAsync(int id)
        {
            var courseEnrollment = await _context.CourseEnrollments.FindAsync(id);
            if (courseEnrollment == null)
            {
                return false;
            }

            _context.CourseEnrollments.Remove(courseEnrollment);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
