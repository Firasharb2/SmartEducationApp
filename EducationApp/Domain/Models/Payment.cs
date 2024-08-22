namespace EducationApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Payment
    {
        [Key] // Primary Key
        public int PaymentId { get; set; }

        [ForeignKey("User")] // Foreign Key
        public int UserId { get; set; }

        [ForeignKey("UserSubscription")] // Foreign Key
        public int UserSubscriptionId { get; set; }

        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsSuccessful { get; set; }

        // Navigation properties
        public User User { get; set; }
        public UserSubscription UserSubscription { get; set; }
    }

}