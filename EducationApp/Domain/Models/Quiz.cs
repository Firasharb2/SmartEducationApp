namespace EducationApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Quiz
    {
        [Key] // Primary Key
        public int QuizId { get; set; }

        [ForeignKey("Lesson")] // Foreign Key
        public int LessonId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int TotalMarks { get; set; }

        // Navigation property
        public Lesson Lesson { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
    }

}