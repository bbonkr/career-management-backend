using CareerManagement.Data.Configurations;
using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CareerManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {

        }

        public DbSet<Career> Careers { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var typeConfiguration in this.GetType().Assembly.GetTypes())
            {
                if (typeConfiguration.IsAssignableFrom(typeof(IEntityTypeConfigurationProvider)))
                {
                    ((IEntityTypeConfigurationProvider)typeConfiguration).Apply(modelBuilder);
                }
            }
        }
    }
}
