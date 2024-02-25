using EventMe.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace EventMe.Core.Models
{
    /// <summary>
    /// EventModel Class
    /// </summary>
    public class EventModel
    {
        /// <summary>
        /// Event Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Event Name
        /// </summary>
        [Required(ErrorMessage = UserMessageConstants.Required)]
        [Display(Name = "Event Name")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = UserMessageConstants.StringLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Event Start Date
        /// </summary>
        [Required(ErrorMessage = UserMessageConstants.Required)]
        [Display(Name = "Event Start Date")]
        public DateTime Start { get; set; }

        /// <summary>
        /// Event End Date
        /// </summary>
        [Required(ErrorMessage = UserMessageConstants.Required)]
        [Display(Name = "Event End Date")]
        public DateTime End { get; set; }

        /// <summary>
        /// Event Place
        /// </summary>
        [Required(ErrorMessage = UserMessageConstants.Required)]
        [Display(Name = "Event Place")]
        public string StreetAddress { get; set; } = "";

        /// <summary>
        /// Town Id
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = UserMessageConstants.Required)]
        [Display(Name = "Town Id")]
        public int TownId { get; set; }

        /// <summary>
        /// Town Name
        /// </summary>
        [Display(Name = "Town Name")]
        public string TownName { get; set; } = "";
    }
}
