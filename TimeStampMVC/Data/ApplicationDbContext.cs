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

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<CardModel> Cards { get; set; }
        public DbSet<StampModel> Stamps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use the connection string from the configuration
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaulConnectionString"));
        }
    }
}
