using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApp.Domain.Students
{
    [Table("students")]

    public class Student
    {
        public int Id { get; set; }                   
        public string FirstName { get; set; }         
        public string LastName { get; set; }          
        public DateTime DateOfBirth { get; set; }     
        public string Email { get; set; }             
        public string PhoneNumber { get; set; }       
        public string Address { get; set; }           
        public string Gender { get; set; }            
        public string StudentNumber { get; set; }     
        public string Program { get; set; }           
        public DateTime EnrollmentDate { get; set; }  
        public double GPA { get; set; }               
    }
}
