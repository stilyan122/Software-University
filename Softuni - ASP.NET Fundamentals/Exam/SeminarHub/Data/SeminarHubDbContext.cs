using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data.Models;

namespace SeminarHub.Data
{
    /// <summary>
    /// Class for DB Context in application
    /// </summary>
    public class SeminarHubDbContext : IdentityDbContext
    {
        /// <summary>
        /// Constructor with DB Options
        /// </summary>
        /// <param name="options">DBContext options to inject (DI)</param>
        public SeminarHubDbContext(DbContextOptions<SeminarHubDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Method called when creating
        /// </summary>
        /// <param name="builder">Default ModelBuilder</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Set primary key to map table
            builder.Entity<SeminarParticipant>()
                .HasKey(sp => new
                {
                    sp.SeminarId,
                    sp.ParticipantId,
                });

            //Set OnDelete default Behaviour
            builder.Entity<SeminarParticipant>()
                .HasOne(sp => sp.Seminar)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            //Populate/Seed the DB
            builder
               .Entity<Category>()
               .HasData(new Category()
               {
                   Id = 1,
                   Name = "Technology & Innovation"
               },
               new Category()
               {
                   Id = 2,
                   Name = "Business & Entrepreneurship"
               },
               new Category()
               {
                   Id = 3,
                   Name = "Science & Research"
               },
               new Category()
               {
                   Id = 4,
                   Name = "Arts & Culture"
               });

            //Call base method
            base.OnModelCreating(builder);
        }

        /// <summary>
        /// DbSet with seminars
        /// </summary>
        public DbSet<Seminar> Seminars { get; set; }

        /// <summary>
        /// DbSet with categories
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// DbSet with seminarsparticipants (map table)
        /// </summary>
        public DbSet<SeminarParticipant> SeminarsParticipants { get; set; }
    }
}