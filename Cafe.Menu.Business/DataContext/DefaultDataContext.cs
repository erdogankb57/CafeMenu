using Cafe.Menu.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Menu.Business.DataContext
{
    public class DefaultDataContext : DbContext
    {

        private readonly IConfiguration _configuration;
        public DefaultDataContext()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultDataContext"));
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Property> Propertys { get; set; }
        public DbSet<ProductProperty> ProductPropertys { get; set; }

    }
}
