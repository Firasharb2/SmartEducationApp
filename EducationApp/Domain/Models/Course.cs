namespace EducationApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        [Key] // Primary Key
        public int CourseId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Syllabus { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }


        [ForeignKey("Instructor")] // Foreign Key
        public int InstructorId { get; set; } // Foreign Key to User

        public string DifficultyLevel { get; set; }
        public string Duration { get; set; }

        [ForeignKey("Category")] // Foreign Key
        public int CategoryId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public Category Category { get; set; }
        public User Instructor { get; set; }
        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<UserRatingReview> UserRatingReviews { get; set; }
        //  public ICollection<DiscussionForum> DiscussionForums { get; set; }      

    }
    //public class Course
    //{
    //    [Key] // Primary Key
    //    public int CourseId { get; set; }
    //    public string Title { get; set; }
    //    public string Description { get; set; }
    //    public string Syllabus { get; set; }
    //    public int InstructorId { get; set; }  // Assuming Instructor is another entity
    //    public string DifficultyLevel { get; set; }
    //    public string Duration { get; set; }
    //    public int CategoryId { get; set; }  // Foreign Key to Category
    //    public DateTime CreatedAt { get; set; }
    //    public DateTime UpdatedAt { get; set; }

    // Navigation properties
    //public Category Category { get; set; }
    //public User Instructor { get; set; }
    //public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    //public ICollection<Lesson> Lessons { get; set; }
    //public ICollection<UserRatingReview> UserRatingReviews { get; set; }

}