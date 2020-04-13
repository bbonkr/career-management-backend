using CareerManagement.Data.Configurations;
using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

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

            modelBuilder.ApplyConfiguration(new CareerLinkTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CareerTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EducationLinkTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EducationTypeConfiguration());
            
            modelBuilder.ApplyConfiguration(new PortfolioFeatureTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PortfolioLinkTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PortfolioTagTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PortfolioTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileLinkTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SkillItemTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SkillTypeConfiguration());
            
            modelBuilder.ApplyConfiguration(new UserLoginTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguratoin());
        }
    }
}
