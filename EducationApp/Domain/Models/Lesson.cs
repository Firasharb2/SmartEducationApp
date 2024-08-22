namespace EducationApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Lesson
    {
        [Key] // Primary Key
        public int LessonId { get; set; }

        [ForeignKey("Course")] // Foreign Key
        public int CourseId { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation property
        public Course Course { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
    }

}
