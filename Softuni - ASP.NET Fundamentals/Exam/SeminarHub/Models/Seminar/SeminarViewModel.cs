namespace SeminarHub.Models.Seminar
{
    /// <summary>
    /// Base Class for seminar view model
    /// </summary>
    public class SeminarViewModel
    {
        /// <summary>
        /// Property for Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property for Topic
        /// </summary>
        public string Topic { get; set; } = string.Empty;

        /// <summary>
        /// Property for Lecturer
        /// </summary>
        public string Lecturer { get; set; } = string.Empty;

        /// <summary>
        /// Property for DateAndTime
        /// </summary>
        public string DateAndTime { get; set; } = string.Empty;

        /// <summary>
        /// Property for Duration (Nullable)
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// Property for Category Name
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Property for Organizer Name
        /// </summary>
        public string Organizer { get; set; } = string.Empty;
    }
}
