namespace EducationApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class QuizQuestion
    {
        [Key] // Primary Key
        public int QuizQuestionId { get; set; }

        [ForeignKey("Quiz")] // Foreign Key
        public int QuizId { get; set; }

        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public string CorrectAnswer { get; set; }
        public string Options { get; set; }

        // Navigation property
        public Quiz Quiz { get; set; }
    }

}