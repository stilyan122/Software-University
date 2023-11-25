using EventMe.Infrastructure.Data.Contracts;

namespace EventMe.Infrastructure.Data.Common
{
    /// <summary>
    /// Methods For Data Access
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Adding An Entity In The Database
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        Task AddAsync<T>(T entity) where T : class;

        /// <summary>
        /// Deleting An Entity From The Database
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="entity">Entity</param>
        void Delete<T>(T entity) where T : class, IDeletable;

        /// <summary>
        /// Retrieving All Entities From A Table
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <returns></returns>
        IQueryable<T> All<T>() where T : class;

        /// <summary>
        /// Retrieving All Entities Plus Deleted From The Database
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <returns></returns>
        IQueryable<T> AllWithDeleted<T>() where T : class, IDeletable;

        // <summary>
        /// Retrieving All Entities Read-Only From The Database
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <returns></returns>
        IQueryable<T> AllReadonly<T>() where T : class;

        /// <summary>
        /// Retrieving All Entities Plus Deleted Read-Only From The Database
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <returns></returns>
        IQueryable<T> AllWithDeletedReadonly<T>() where T : class, IDeletable;

        /// <summary>
        /// Retrieving An Entity By Id
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="id">Entity Id</param>
        /// <returns></returns>
        Task<T?> GetById<T>(int id) where T : class;

        /// <summary>
        /// Saving Changes In The Database
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }
}
