namespace EventMe.Infrastructure.Data.Contracts
{
    /// <summary>
    /// Entity Which Can Be Deleted
    /// </summary>
    public interface IDeletable
    {
        /// <summary>
        /// The Record / Entity Is Active (Present In The Database)
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Date Of Removal
        /// </summary>
        DateTime? DeletedOn { get; set; }
    }
}
