namespace P01_StudentSystem.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

            //builder.HasOne(sc => sc.Student)
            //    .WithMany(s => s.StudentsCourses)
            //    .HasForeignKey(sc => sc.StudentId);

            //builder.HasOne(sc => sc.Course)
            //    .WithMany(c => c.StudentsCourses)
            //    .HasForeignKey(sc => sc.CourseId);
        }
    }
}