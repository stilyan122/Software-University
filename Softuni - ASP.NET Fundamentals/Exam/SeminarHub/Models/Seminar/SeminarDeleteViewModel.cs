namespace SeminarHub.Models.Seminar
{
    /// <summary>
    /// Class for seminar view model, used when we delete a seminar
    /// </summary>
    public class SeminarDeleteViewModel
    {
        /// <summary>
        /// Property for Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property for DateAndTime
        /// </summary>
        public DateTime DateAndTime { get; set; }

        /// <summary>
        /// Property for Lecturer
        /// </summary>
        public string Lecturer { get; set; } = string.Empty;

        /// <summary>
        /// Property for Topic
        /// </summary>
        public string Topic { get; set; } = string.Empty;
    }
}
