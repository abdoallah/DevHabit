using Microsoft.EntityFrameworkCore;

namespace DevHabit.Api.Database
{
    public sealed class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)
    {

        public DbSet<Entities.Habit> Habits { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schemas.DevHabit);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);

        }
    }
}
