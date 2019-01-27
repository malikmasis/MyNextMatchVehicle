using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MNMVehicleMVC.Model;
using System.IO;

namespace MNMVehicleMVC.Data
{
    public class postgresContext : DbContext,IStoreAppContext
    {
        public DbSet<User> User { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public DbSet<Vehicle> Vehicle { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public postgresContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("postgresContext");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack")
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");
        }
    }
}
