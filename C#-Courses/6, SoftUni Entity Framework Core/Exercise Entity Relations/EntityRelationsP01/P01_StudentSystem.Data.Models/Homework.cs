namespace P01_StudentSystem.Data.Models;

using P01_StudentSystem.Data.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Homework
{
    [Key]
    public int HomeworkId { get; set; }


    [Required]
    public string Content { get; set; } = null!;

    [Required]
    public ContentType ContentType { get; set; }

    [Required]
    public DateTime SubmissionTime { get; set; }


    [ForeignKey(nameof(Student))]
    public int StudentId { get; set; }
    public virtual Student Student { get; set; } = null!;

    public int CourseId { get; set; }
    public virtual Course Course { get;set; } = null!;
}

