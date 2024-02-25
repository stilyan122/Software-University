namespace ForumApp.Infrastructure.Data
{
    using ForumApp.Infrastructure.Data.Configurations;
    using ForumApp.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// ForumAppDbContext class => DB Context
    /// </summary>
    public class ForumAppDbContext : DbContext
    {
        /// <summary>
        /// Constructor for setting default options
        /// </summary>
        /// <param name="options"></param>
        public ForumAppDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        /// <summary>
        /// DbSet for app posts
        /// </summary>
        public DbSet<Post> Posts { get; set; } = null!;

        /// <summary>
        /// Method for applying configurations
        /// </summary>
        /// <param name="modelBuilder">Model Builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Post>(new PostConfiguration());
        }
    }
}
