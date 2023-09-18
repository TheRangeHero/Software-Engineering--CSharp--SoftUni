namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;
public class Student
{
    public Student()
    {
        this.StudentsCourses = new HashSet<StudentCourse>();
        this.Homeworks = new HashSet<Homework>();
    }

    [Key]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(ValidationConstraints.StudentNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(ValidationConstraints.StudentPhoneNumberMaxLength)]
    public string? PhoneNumber { get; set; }

    [Required]
    public DateTime RegisteredOn { get; set; }

    public DateTime? Birthday { get;set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
    public virtual ICollection<Homework> Homeworks { get; set; }
}