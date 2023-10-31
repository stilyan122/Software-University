using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace P01_StudentSystem.Data.Models.Configuration
{
    public class StudentCourseConfiguration :
        IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder
                .HasKey(sc => new {sc.StudentId , sc.CourseId})
                .HasName("Constraint_Student_CoursePK");

            builder
                .HasOne(sc => sc.Course)
                .WithMany(sc => sc.StudentsCourses)
                .HasForeignKey(sc => sc.CourseId);

            builder
                .HasOne(sc => sc.Student)
                .WithMany(sc => sc.StudentsCourses)
                .HasForeignKey(sc => sc.StudentId);
        }
    }
}
