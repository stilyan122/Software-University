using EventMe.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EventMe.Infrastructure.Data
{
    /// <summary>
    /// Database Context
    /// </summary>
    public class EventMeDbContext : DbContext
    {
        /// <summary>
        /// Constructor For Database Context
        /// </summary>
        /// <param name="options">Database Context Options</param>
        public EventMeDbContext(DbContextOptions<EventMeDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(EventMeDbContext).Assembly);
        }

        /// <summary>
        /// Set Of Events
        /// </summary>
        public DbSet<Event> Events { get; set; } = null!;

        /// <summary>
        /// Set Of Towns
        /// </summary>
        public DbSet<Town> Towns { get; set; } = null!;

        /// <summary>
        /// Set Of Event Addresses
        /// </summary>
        public DbSet<Address> Addresses { get; set; } = null!;
    }
}
