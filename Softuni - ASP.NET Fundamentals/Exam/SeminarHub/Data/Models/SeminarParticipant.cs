using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data.Models
{
    /// <summary>
    /// SeminarParticipant Class => Mapping Table
    /// </summary>
    [Comment("SeminarParticipant Class => Mapping Table")]
    public class SeminarParticipant
    {
        /// <summary>
        /// Seminar Id => Foreign Key, 1/2 Primary Key
        /// </summary>
        [ForeignKey(nameof(Seminar))]
        [Comment("Seminar Id")]
        public int SeminarId { get; set; }
        
        /// <summary>
        /// Seminar Object
        /// </summary>
        public Seminar Seminar { get; set; } = null!;

        /// <summary>
        /// Participant Id => Foreign Key, 1/2 Primary Key
        /// </summary>
        [Comment("Participant Id")]
        [ForeignKey(nameof(Participant))]
        public string ParticipantId { get; set; } = string.Empty;

        /// <summary>
        /// Participant => IdentityUser
        /// </summary>
        public IdentityUser Participant { get; set; } = null!;
    }
}
