using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [Unicode]
        [MaxLength(80)]
        public string Name { get; set; }

        [Unicode]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<StudentCourse> StudentsCourses { get; set; } =
            null!;

        public virtual ICollection<Resource> Resources { get; set; } =
            null!;

        public virtual ICollection<Homework> Homeworks { get; set; } =
            null!;
    }
}
