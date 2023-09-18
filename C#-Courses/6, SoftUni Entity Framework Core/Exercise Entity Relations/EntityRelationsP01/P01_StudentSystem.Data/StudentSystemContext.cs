namespace P01_StudentSystem.Data;

using Microsoft.EntityFrameworkCore;


using Common;
using P01_StudentSystem.Data.Models;
using P01_StudentSystem.Data.EntityConfiguration;

public class StudentSystemContext : DbContext
{

    public StudentSystemContext()
    {
    }
    public StudentSystemContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; } 
    public DbSet<Course> Courses { get; set; } 
    public DbSet<Resource> Resources { get; set; } 
    public DbSet<Homework> Homeworks { get; set; } 
    public DbSet<StudentCourse> StudentsCourses { get; set; } 


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(DbConfig.Connection_String);
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        //modelBuilder.ApplyConfiguration(new StudentConfiguration());

        //modelBuilder.ApplyConfiguration(new CourseConfiguration());

        //modelBuilder.ApplyConfiguration(new ResourcesConfiguration());

        //modelBuilder.ApplyConfiguration(new HomeworkConfiguration());

        //modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(x => new { x.StudentId, x.CourseId });
        });
    }
}