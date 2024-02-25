namespace SeminarHub.Data.Constants
{
    /// <summary>
    /// Static class for data constants
    /// </summary>
    public static class DataConstants
    {
        /// <summary>
        /// Static class for seminar properties' constants
        /// </summary>
        public static class SeminarConstants 
        {
            public const int TopicMinLength = 3;
            public const int TopicMaxLength = 100;

            public const int LecturerMinLength = 5;
            public const int LecturerMaxLength = 60;

            public const int DetailsMinLength = 10;
            public const int DetailsMaxLength = 500;

            public const string DateTimeFormat = "dd/MM/yyyy HH:mm";

            public const int DurationMinValue = 30;
            public const int DurationMaxValue = 180;
        }

        /// <summary>
        /// Static class for category properties' constants
        /// </summary>
        public static class CategoryConstants
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }

        /// <summary>
        /// Static class for error messages
        /// </summary>
        public static class ErrorConstants
        {
            public const string RequiredErrorMessage = "Field {0} is required!";

            public const string RangeErrorMessage = "Field {0} must be from {1} to {2} long!";

            public const string LengthErrorMessage = "Fiel {0} must be from {2} to {1} characters long!";
        }
    }
}
