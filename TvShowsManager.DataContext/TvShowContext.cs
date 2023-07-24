using Microsoft.EntityFrameworkCore;
using TvShowsManager.Models.DataModels;

namespace TvShowsManager.DataContext
{
    public class TvShowContext : DbContext
    {
        //Build application context and configurations
        public TvShowContext() { }

        public TvShowContext(DbContextOptions<TvShowContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        //Here we add the the DbSets
        public DbSet<Show> Shows { get; set; }
    }
}