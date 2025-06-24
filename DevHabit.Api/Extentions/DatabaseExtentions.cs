using DevHabit.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace DevHabit.Api.Extentions
{
    public static class DatabaseExtentions
    {
        public static async Task MigrateDatabaseAsync(this WebApplication app)
        {
            using IServiceScope scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();

            try
            {
                await dbContext.Database.MigrateAsync();

                app.Logger.LogInformation("Database migration completed successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                
                app.Logger.LogError(ex, "An error occurred while migrating the database.");
                throw;
            }

        }
    }
}
