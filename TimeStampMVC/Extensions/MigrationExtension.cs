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
                using IServiceScope scope = app.ApplicationServices.CreateScope();
                using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                Console.WriteLine("db sucessfully created");
                DbInitializer.Initialize(dbContext);
                Console.WriteLine("sample data inserted into db");
            }
            catch (Exception ex)
            {
                Console.WriteLine("no migration applied" + ex.Message);
            }
        }
    }
}
