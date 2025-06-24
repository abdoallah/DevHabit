using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevHabit.Api.Database.Configurations
{
    public sealed class HabitConfiguration : IEntityTypeConfiguration<Entities.Habit>
    {
        public void Configure(EntityTypeBuilder<Entities.Habit> builder)
        {
            builder.ToTable("Habits");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(h => h.Description)
                .HasMaxLength(500);
            
            builder.Property(h => h.Status);
            builder.Property(h => h.IsArchived);

            builder.Property(h => h.CreartedAtUtc)
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(h => h.UpdatedAtUtc)
                .HasColumnType("datetime2");

            builder.Property(h => h.EndDate)
                .HasColumnType("date");

            builder.HasIndex(h => h.Name).IsUnique();
        }
    }
}
