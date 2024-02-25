namespace SeminarHub.Models.Seminar
{
    /// <summary>
    /// Class for seminar view model, used when we want to see the details of a seminar 
    /// It inherits the base seminar view model
    /// </summary>
    public class SeminarDetailsViewModel : SeminarViewModel
    {
        /// <summary>
        /// Property for Details
        /// </summary>
        public string Details { get; set; } = string.Empty;
    }
}
