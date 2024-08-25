namespace EducationApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CourseEnrollment
    {
        [Key] // Primary Key
        public int CourseEnrollmentId { get; set; }

        [ForeignKey("Course")] // Foreign Key
        public int CourseId { get; set; }

        public string UserId { get; set; }

        public DateTime? EnrolledAt { get; set; }
        public string? Grade { get; set; }
        public string? CertificateUrl { get; set; }
        public DateTime? CompletedAt { get; set; }

        // Navigation properties
        public Course? Course { get; set; }
    }

}