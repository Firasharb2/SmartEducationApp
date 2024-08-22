namespace EducationApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserRatingReview
    {
        [Key] // Primary Key
        public int UserRatingReviewId { get; set; }

        [ForeignKey("Course")] // Foreign Key
        public int CourseId { get; set; }

        [ForeignKey("User")] // Foreign Key
        public int UserId { get; set; }

        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public Course Course { get; set; }
        public User User { get; set; }
    }

}