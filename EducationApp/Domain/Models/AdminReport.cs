namespace EducationApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AdminReport
    {
        [Key] // Primary Key
        public int AdminReportId { get; set; }

        public int UserId { get; set; }

        public string ReportType { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property
    }

}

