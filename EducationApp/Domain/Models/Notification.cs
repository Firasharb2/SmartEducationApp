namespace EducationApp.Domain.Models

{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Notification
    {
        [Key] // Primary Key
        public int NotificationId { get; set; }

        [ForeignKey("User")] // Foreign Key
        public int UserId { get; set; }

        public string Content { get; set; }
        public string Type { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property
    }

}
