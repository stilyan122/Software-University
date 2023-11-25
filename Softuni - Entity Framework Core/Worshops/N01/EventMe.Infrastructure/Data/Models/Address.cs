using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventMe.Infrastructure.Data.Models
{
    /// <summary>
    /// Place Of Event Venue Class
    /// </summary>
    [Comment("Place Of Event Venue")]
    public class Address
    {
        /// <summary>
        /// Place Id
        /// </summary>
        [Key]
        [Comment("Place Id")]
        public int Id { get; set; }

        /// <summary>
        /// Town Id
        /// </summary>
        [Required]
        [Comment("Town Id")]
        public int TownId { get; set; }

        /// <summary>
        /// Place Address
        /// </summary>
        [Required]
        [Comment("Place Address")]
        [MaxLength(100)]
        public string StreetAddress { get; set; } = null!;

        /// <summary>
        /// Town Entity
        /// </summary>
        [Required]
        [Comment("Town Entity")]
        [ForeignKey(nameof(TownId))]
        public Town Town { get; set; } = null!;
    }
}
