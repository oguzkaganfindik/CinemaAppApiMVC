using CinemaApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Context
{
    public class CinemaAppContext : DbContext
    {
        public CinemaAppContext(DbContextOptions<CinemaAppContext> options) : base (options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieEntity>().HasQueryFilter(x => x.IsDeleted == false);

            // TODO: bu üstteki kod olmadan da istek atmayı dene => SoftDelete ile True olanları döndürmez.

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<MovieEntity> Movies => Set<MovieEntity>();
    }
}
