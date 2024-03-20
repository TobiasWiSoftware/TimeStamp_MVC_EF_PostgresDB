using Microsoft.EntityFrameworkCore;
using System;
using TimeStampMVC.Data;
using TimeStampMVC.DataSeed;

namespace TimeStampMVC.Extensions
{
    public static class MigrationExtension
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            try
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    // Check if the database exists
                    var dbExists = dbContext.Database.CanConnect();

                    if (!dbExists)
                    {
                        // Ensure the database is created. This does not apply migrations.

                        Console.WriteLine("Database does not exist");
                    }
                    else
                    {
                        // Apply any pending migrations
                        dbContext.Database.Migrate();
                        Console.WriteLine("Database successfully updated with Migrate.");

                    }

                    // Seed the database with initial data
                    DbInitializer.Initialize(dbContext);
                    Console.WriteLine("Sample data inserted into db");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while applying migrations or seeding the database: {ex.Message}");
            }
        }
    }
}
