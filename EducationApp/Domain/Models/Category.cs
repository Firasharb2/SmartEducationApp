namespace EducationApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        [Key] // Primary Key
        public int CategoryId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public ICollection<Course> Courses { get; set; }
    }

}