using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }

        [Required]
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; } = null!;

        public int CourseId { get; set; }

        [Required]
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; } = null!;
    }
}
