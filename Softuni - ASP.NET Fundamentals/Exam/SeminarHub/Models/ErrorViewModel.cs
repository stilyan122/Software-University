namespace SeminarHub.Models
{
    /// <summary>
    /// Basic class for error view model
    /// </summary>
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}