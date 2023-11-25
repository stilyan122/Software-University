using EventMe.Core.Models;

namespace EventMe.Core.Contracts
{
    /// <summary>
    /// Event Service
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Creating An Event
        /// </summary>
        /// <param name="model">EventModel</param>
        /// <returns></returns>
        Task CreateAsync(EventModel model);

        /// <summary>
        /// Deleting An Event
        /// </summary>
        /// <param name="id">Event Id</param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Editing An Event
        /// </summary>
        /// <param name="model">EventModel</param>
        /// <returns></returns>
        Task EditAsync(EventModel model);

        /// <summary>
        /// Retriving An Event By Id
        /// </summary>
        /// <param name="id">Event Id</param>
        /// <returns></returns>
        Task<EventModel> GetByIdAsync(int id);

        /// <summary>
        /// Retriving All Events
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventModel>> GetAllAsync();

        /// <summary>
        /// Retriving All Towns
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TownModel>> GetTownsAsync();
    }
}
