namespace EducationApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SubscriptionPlan
    {
        [Key] // Primary Key
        public int SubscriptionPlanId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string AccessLevel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<UserSubscription> UserSubscriptions { get; set; }
    }

}