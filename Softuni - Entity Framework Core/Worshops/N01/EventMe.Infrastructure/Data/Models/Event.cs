using EventMe.Infrastructure.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventMe.Infrastructure.Data.Models
{
    /// <summary>
    /// Event Entity Class (Which Is Deletable)
    /// </summary>
    [Comment("Event Class (Which Is Deletable)")]
    public class Event : IDeletable
    {
        /// <summary>
        /// Event Id
        /// </summary>
        [Comment("Event Id")]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Event Name
        /// </summary>
        [Required]
        [Comment("Event Name")]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Event Start Date
        /// </summary>
        [Required]
        [Comment("Event Start Date")]
        public DateTime Start { get; set; }

        /// <summary>
        /// Event End Date
        /// </summary>
        [Required]
        [Comment("Event End Date")]
        public DateTime End { get; set; }

        /// <summary>
        /// Place Id
        /// </summary>
        [Required]
        [Comment("Place Id")]
        public int PlaceId { get; set; }

        /// <summary>
        /// The Event Is Active (true / false)
        /// </summary>
        [Required]
        [Comment("The Event Is Active (true / false)")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Date Of Removal
        /// </summary>
        [Comment("Date Of Removal")]
        public DateTime? DeletedOn { get; set; }

        /// <summary>
        /// Place Of Event Vanue
        /// </summary>
        [Required]
        [Comment("Place Of Event Vanue")]
        [ForeignKey(nameof(PlaceId))]
        public Address Place { get; set; } = null!;
        
    }
}
