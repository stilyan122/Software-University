using Microsoft.EntityFrameworkCore;

namespace EventMe.Infrastructure.Data.Common
{
    /// <summary>
    /// Methods For Data Access
    /// </summary>
    public class Repository : IRepository
    {
        private readonly EventMeDbContext dbContext;

        /// <summary>
        /// Constructor For Injecting The Context Of The Database
        /// </summary>
        /// <param name="_dbContext">Контекста на базата данни</param>
        public Repository(EventMeDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// Returns DbSet<typeparamref name="T"/> Of A Given Type
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <returns></returns>
        private DbSet<T> DbSet<T>() where T : class => dbContext.Set<T>();

        /// <summary>
        /// Adding An Element In The Database
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        /// <summary>
        /// Retrieving All Elements From The Database
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <returns></returns>
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        // <summary>
        /// Retrieving All Elements From The Database Read-Only
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <returns></returns>
        public IQueryable<T> AllReadonly<T>() where T : class
        {
            return DbSet<T>()
                .AsNoTracking();
        }

        /// <summary>
        /// Retrieving An Element By Id
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="id">Entity Id</param>
        /// <returns></returns>
        public async Task<T?> GetById<T>(int id) where T : class
        {
            return await DbSet<T>()
                .FindAsync(id);
        }

        /// <summary>
        /// Saving Changes In The Database
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deleting An Element From The Database
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="entity">Entity</param>
        void IRepository.Delete<T>(T entity)
        {
            entity.IsActive = false;
            entity.DeletedOn = DateTime.Now;
        }

        /// <summary>
        /// Retrieving All Elements Plus Deleted From The Database
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <returns></returns>
        IQueryable<T> IRepository.AllWithDeleted<T>()
        {
            return DbSet<T>()
                .IgnoreQueryFilters();
        }

        /// <summary>
        /// Retrieving All Elements Plus Deleted From The Database Read-Only
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <returns></returns>
        IQueryable<T> IRepository.AllWithDeletedReadonly<T>()
        {
            return DbSet<T>()
                .IgnoreQueryFilters()
                .AsNoTracking();
        }
    }
}
