namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;
using Models.Enums;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }

    [Required]
    [MaxLength(ValidationConstraints.ResourceNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public string Url { get; set; } = null!;

    [Required]
    public ResourceType ResourceType { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
}
