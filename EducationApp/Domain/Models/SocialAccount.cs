namespace EducationApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SocialAccount
    {
        [Key] // Primary Key
        public int SocialAccountId { get; set; }

        [ForeignKey("User")] // Foreign Key
        public int UserId { get; set; }

        public string Provider { get; set; }
        public string ProviderUserId { get; set; }
        public DateTime LinkedAt { get; set; }

        // Navigation property
        public User User { get; set; }
    }

}