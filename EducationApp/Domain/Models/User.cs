namespace EducationApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key] // Primary Key
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ProfilePicture { get; set; }
        public string Bio { get; set; }

        [Required]
        public UserRole Role { get; set; } // Enum for Role

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? LastLogin { get; set; }

        // Navigation properties
        public ICollection<SocialAccount> SocialAccounts { get; set; }
        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
        public ICollection<QuizResult> QuizResults { get; set; }
        //  public ICollection<ForumPost> ForumPosts { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<UserRatingReview> UserRatingReviews { get; set; }
        public ICollection<UserSubscription> UserSubscriptions { get; set; }
        public ICollection<Payment> Payments { get; set; }
        //   public ICollection<Invoice> Invoices { get; set; }
        public ICollection<AdminReport> AdminReports { get; set; }

        // Constructor
        public User()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}