using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security;
using TimeStampLibary.Models;

namespace TimeStampMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<StamperModel> Stamper { get; set; }
        public DbSet<StampModel> Stamp { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use the connection string from the configuration
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaulConnectionString"));
        }
    }
}
