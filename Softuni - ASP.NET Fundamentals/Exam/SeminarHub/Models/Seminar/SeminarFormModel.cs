using SeminarHub.Models.Category;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.Constants.DataConstants.ErrorConstants;
using static SeminarHub.Data.Constants.DataConstants.SeminarConstants;

namespace SeminarHub.Models.Seminar
{
    /// <summary>
    /// Class for seminar view model, used when submitting a form (+its validations)
    /// </summary>
    public class SeminarFormModel
    {
        /// <summary>
        /// Property for Topic (Required)
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(TopicMaxLength,
            MinimumLength = TopicMinLength, 
            ErrorMessage = LengthErrorMessage)]
        public string Topic { get; set; } = string.Empty;

        /// <summary>
        /// Property for Lecturer (Required)
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(LecturerMaxLength,
            MinimumLength = LecturerMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string Lecturer { get; set; } = string.Empty;

        /// <summary>
        /// Property for Details (Required)
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DetailsMaxLength,
            MinimumLength = DetailsMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string Details { get; set; } = string.Empty;

        /// <summary>
        /// Property for DateAndTime *formatted => string* (Required)
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        public string DateAndTime { get; set; } = string.Empty;

        /// <summary>
        /// Property for Duration (Nullable)
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(DurationMinValue, DurationMaxValue, 
            ErrorMessage = RangeErrorMessage)]
        public int? Duration { get; set; }

        /// <summary>
        /// Property for CategoryId (Required)
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        public int CategoryId { get; set; }

        /// <summary>
        /// Property for Collection of categories
        /// </summary>
        public IEnumerable<CategoryViewModel> Categories { get; set; }
            = new List<CategoryViewModel>();
    }
}
