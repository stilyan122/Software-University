using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SeminarHub.Data.Constants.DataConstants.SeminarConstants;

namespace SeminarHub.Data.Models
{
    /// <summary>
    /// Seminar Entity Class
    /// </summary>
    [Comment("Seminar Entity Class")]
    public class Seminar
    {
        /// <summary>
        /// Seminar Id => Primary Key
        /// </summary>
        [Key]
        [Comment("Seminar Id => Primary Key")]
        public int Id { get; set; }

        /// <summary>
        /// Seminar Topic
        /// </summary>
        [Required]
        [MaxLength(TopicMaxLength)]
        [Comment("Seminar Topic")]
        public string Topic { get; set; } = string.Empty;

        /// <summary>
        /// Seminar Lecturer
        /// </summary>
        [Required]
        [MaxLength(LecturerMaxLength)]
        [Comment("Seminar Lecturer")]
        public string Lecturer { get; set; } = string.Empty;

        /// <summary>
        /// Seminar Details
        /// </summary>
        [Required]
        [MaxLength(DetailsMaxLength)]
        [Comment("Seminar Details")]
        public string Details { get; set; } = string.Empty;

        /// <summary>
        /// Seminar Organizer Id => Foreign Key
        /// </summary>
        [Required]
        [ForeignKey(nameof(Organizer))]
        [Comment("Seminar OrganizerId => Foreign Key")]
        public string OrganizerId { get; set; } = string.Empty;

        /// <summary>
        /// Seminar Organizer => IdentityUser
        /// </summary>
        [Required]
        public IdentityUser Organizer { get; set; } = null!;

        /// <summary>
        /// Seminar DateAndTime => DateTime Object
        /// </summary>
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, 
            DataFormatString = DateTimeFormat)]
        [Comment("Seminar DateAndTime")]
        public DateTime DateAndTime { get; set; }

        /// <summary>
        /// Seminar Duration
        /// </summary>
        [Range(DurationMinValue, DurationMaxValue)]
        [Comment("Seminar Duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// Seminar Category Id => Foreign Key
        /// </summary>
        [Required]
        [ForeignKey(nameof(Category))]
        [Comment("Seminar Category Id => Foreign Key")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Seminar Category
        /// </summary>
        [Required]
        public Category Category { get; set; } = null!;

        /// <summary>
        /// Collection of SeminarsParticipants
        /// </summary>
        public IEnumerable<SeminarParticipant> SeminarsParticipants 
            { get; set; } = new List<SeminarParticipant>();
    }
}
