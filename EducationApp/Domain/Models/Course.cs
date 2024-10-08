﻿namespace EducationApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        [Key] // Primary Key
        public int CourseId { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Syllabus { get; set; }
        public string? ImageUrl { get; set; }
        public string? Url { get; set; }
        public decimal? Price { get; set; }


        public int? UserId { get; set; } // Foreign Key to User

        public string? DifficultyLevel { get; set; }
        public string? Duration { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<CourseEnrollment>? CourseEnrollments { get; set; }
        public ICollection<Lesson>? Lessons { get; set; }
        public ICollection<UserRatingReview>? UserRatingReviews { get; set; }

    }
  
}