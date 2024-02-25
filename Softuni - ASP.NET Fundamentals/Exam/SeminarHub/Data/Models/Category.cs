using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.Constants.DataConstants.CategoryConstants;

namespace SeminarHub.Data.Models
{
    /// <summary>
    /// Category Entity Class
    /// </summary>
    [Comment("Category Entity Class")]
    public class Category
    {
        /// <summary>
        /// Category Id => Primary Key
        /// </summary>
        [Key]
        [Comment("Category Id => Primary Key")]
        public int Id { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Category Name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Collection of category seminars
        /// </summary>
        public IEnumerable<Seminar> Seminars { get; set; }
            = new List<Seminar>();
    }
}
