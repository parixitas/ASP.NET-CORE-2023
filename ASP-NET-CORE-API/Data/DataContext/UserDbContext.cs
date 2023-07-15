using ASP_NET_CORE_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ASP_NET_CORE_API.Data.DataContext
{
    public class UserDbContext : DbContext
    {

        public UserDbContext()
        {

        }

        public UserDbContext(DbContextOptions options)
         : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAddresses> UserAddresses { get; set; }
        public virtual DbSet<UserSocialMedia> UserSocialMedias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DbConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
