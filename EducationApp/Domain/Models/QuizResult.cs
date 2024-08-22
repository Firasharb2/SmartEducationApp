namespace EducationApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class QuizResult
    {
        [Key] // Primary Key
        public int QuizResultId { get; set; }

        [ForeignKey("Quiz")] // Foreign Key
        public int QuizId { get; set; }

        [ForeignKey("User")] // Foreign Key
        public int UserId { get; set; }

        public double Score { get; set; }
        public DateTime CompletedAt { get; set; }

        // Navigation properties
        public Quiz Quiz { get; set; }
        public User User { get; set; }
    }

}