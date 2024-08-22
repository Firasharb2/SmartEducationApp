namespace EducationApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserSubscription
    {
        [Key] // Primary Key
        public int UserSubscriptionId { get; set; }

        [ForeignKey("User")] // Foreign Key
        public int UserId { get; set; }

        [ForeignKey("SubscriptionPlan")] // Foreign Key
        public int SubscriptionPlanId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        // Navigation properties
        public User User { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }
    }

}