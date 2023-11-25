using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EventMe.Infrastructure.Data.Models
{
    /// <summary>
    /// Town Entity Class
    /// </summary>
    [Comment("Town Entity Class")]
    public class Town
    {
        /// <summary>
        /// Town Id
        /// </summary>
        [Key]
        [Comment("Town Id")]
        public int Id { get; set; }

        /// <summary>
        /// Town Name
        /// </summary>
        [Required]
        [Comment("Town Name")]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
    }
}
